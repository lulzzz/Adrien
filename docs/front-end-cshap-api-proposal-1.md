# Front-end APIs for Adrien
> By Joannes Vermorel, May 2018

Status: EARLY DRAFT

This document is a tentative to define the overall look-and-feel of a C# front-end API for Adrien.

Todos:

* 2-stage compilation (dims first, TC second)
* weight initialization
* columnar data-feeding pattern with chunks
* discuss need for complex constants
* dynamic generation of input datasets
* `Ndarray` with `Memory<float>` or `Span<float>`

## Basic concepts

Adrien resolves around the concept of _computation network_ which can be automatically differentiated in order to learn from a dataset. The definition of a such a network is typically done at the _symbolic_ level, through a graph - referred as the _tensor graph_ - of _tensors_ and _tensor comprehensions_ (or simply _comprehensions_). The tensors, i.e. the variables of the computation, are glued together by the comprehensions, which can be seen as the high level operators over the tensors.

This tensor graph can be compiled into the _compute graph_. The compute graph is the numeric counterpart of original symbolic graph. The compute graph involves _ND array_ (counterparts of tensors) and _kernels_ (counterparts of comprehensions).

Tensors and ND arrays are represented by the classes `Tensor` and `Ndarray` respectively. Through a `TensorContext`, a graph of `Tensor` is built, which results in a `TensorGraph` object. The compilation of the `TensorGraph` goes in two stages: (A) infer all tensor dimensions (B) generate the tensor comprehensions.

The base class `Tensor` is an untyped generic tensor; it is intended for a "programmatic" use case. The classes `Tensor1`, `Tensor2`, `Tensor3` only specifies the number of dimensions by not the dimension themselves. Finally, the `Tensor<D1, D2, D3>` generic descendants of `Tensor` are encoding the tensor dimensions through the generics. They lend themselves to some degree of type-inference support from C#.

```
// untyped generic tensor
class Tensor 
{ 
    public TensorContext Context { get; } // snipped
}

// 1D, 2D and 3D tensors, dim-untyped
class Tensor1 : Tensor {}
class Tensor2 : Tensor {}
class Tensor3 : Tensor {}

// dimension of a tensor
interface IDim { int Dim {get;} }

// 1D tensor, dim-typed
class Tensor<D1> : Tensor1 where D1 : IDim { }

// 2D tensor, dim-typed
class Tensor<D1, D2> : Tensor2 
  where D1 : IDim, D2 : IDim { }

// 3D tensor, dim-typed
class Tensor<D1, D2, D3> : Tensor3 
  where D1 : IDim, D2 : IDim, D3 : IDim { }
```

## Introductive example

The code below illustrates a minimal model training through SGD. We are adopting a naïve data streaming pattern where inputs are provided as _tabular_ data. However, in practice, it's important to also support a _columnar_ scenario.

```
class DH : IDim { Dim => 128; }
class D1 : IDim { Dim => 1; }

// naive tabular inputs
class MyInput
{
    public float[] Y {get;set;}
    public float z {get; set;}
}

void Main()
{
    // context intended for model persistence scenarios
    var T = new TensorContext();
    var TC = T.Comprehensions;

    // binding inputs to 'MyInput'
    var Y = T.New<DH>.Input<MyInput>(
        (in, nda) => // MyInput * Ndarray 
        {
            // avoid chatty calls to anonymous function
            for(var i = 0; i < in.Y.Length; i++) 
            { 
                nda[i] = in.Y[i]; 
            }
        }
    );

    var z = T.New<D1>.Input<MyInput>(
        (in, nda) => { nda[0] = in.z; });

    // X1 is Tensor<DH>
    // A is Tensor2, dims to be inferred as (DH, DH)
    // b is Tensor<DH>
    var (X1, A, b) = TC.Dense<DH>(Y); // ReLU by default
    var (X2, _, _) = TC.Dense<DH>(X1).WithReLU();

    // "manual" layer definition
    var A3 = T.New2(); // Tensor2, dims inferred
    var b3 = T.New<DH>(); // Tensor<DH>
    var X3 = TC.ReLU(A3 * X2 + b3);

    // constant ad-hoc 2D tensor (circulant matrix)
    // explicit init flags tensor as 'constant'
    var A4 = T.NewConstant(
        (i, j, dimI, dimJ) => 
            i == j + 1 || (i == 0 && j == dimJ - 1)
            ? 1f 
            : 0f);
    
    // cyclic permutation applied on 'X3'
    var X4 = A4 * X3;

    // Final layer connected 'X3' (not X4)
    var (Z, _, _) = TC.Linear<D1>(X3).WithSigmoid();

    var loss = TC.MeanSquare(z, Z);

    // Grab the whole graph from the criterion.
    // Unreachable elements can be added as 'outputs'.
    // note: missing 'metrics' (ala CNTK)
    var tg = new TensorGraph(
        criterion: loss,
        outputs: new[] {X4} // X4 not reachable otherwise
    );

    var cg = tg.Compile(); // cg = compute graph

    // assuming proper data
    IEnumerable<MyInput> examples = ...; // snipped 
    
    // stream 'batches' of inputs
    var minibatch = new Minibatch(
        examples, 
        batchSize: 64,
        randomize: true);

    // initialize the weights
    CGInit.Glorot(cg, minibatch);

    // configuring the SGD
    var descent = SGD.RMSProp(cg);
    for(int i = 0; i < 1000; i++)
    {
        descent.Do(minibatch);
    }

    // retrieve from device
    cg = desc.GetComputeGraph();

    // isolate a parameter tensor
    Ndarray vA = cg.Get(A);

    MyInput in = ...; // snipped

    // model evaluation 
    Ndarray x4e = cg.Eval(in, X4);
}
```

## Four statuses of tensors

The tensor graph involves two types of nodes: tensors and tensor comprehensions. The directed edges indicates the inputs and outputs of tensor comprehensions. On the tensor side, we have four distinct statuses for the tensors:

* **constant tensors** are externally defined, they are treated as constants from the SGD perspective. From the differentiable programming perspective, those tensors might be modified in-between two SGD phases, but those changes are operated by the client. 
* **input tensors** are populated through the data feeding process of the computational graph. From an SGD perspective, those tensors are also treated as constant. However, they are not _external_ to the SGD process, as they are part of the minibatch process.
* **flow tensors** are (functionally) pure functional result of calculations within the graph, and the bulk of them are only intermediate results. Some flow tensors are referred as the output of the network, but being an "output" tensor does have any numerical impact.
* **parameter tensors** contains what is commonly referred as the _weight_. They are randomly initialized, and the whole point of the training phase is to discover the most efficient set of parameters with respect to the criterion.

## Dimensional inference

The use of tensors allows a concise yet readable syntax to be used in C#. However, the type system of C# itself does not support a complete inference of the tensor dimensions. Instead of expecting the client code of Adrien to painstakingly specific every single dimension, Adrien opts for a more liberal approach where dimensions are mostly inferred based on the _dimensional constraints_.

Constraints can be expressed when instantiating a tensor down to a full specification of all its dimensions, but constraints can also be expressed as equations combining tensors through comprehensions.

```
public Tensor<D> Dense<D>(Tensor in)
{
    var T = in.Context;

    var A = T.New(); // no dims specified
    var b = T.New<D>(); // 1D of dim 'D'
    var res = T.New<D>(); // 1D of dim 'D

    // 'A' starts with dim 'D', followed (right) by all dims of 'in'
    T.BindOnRight<D>(A, in);

    // a tensor comprehension is produced here
    // which becomes part of the context
    // returning the resulting tensor to keep code fluid
    return T.New(
        inputs: new [] {in},
        params: new [] {A, b}
        outputs: new [] {res},
        factory: tcb => // tcb = tensor comprehension builder
        {
            // at this point, all dimensions have been inferred
            var i = tcb.NewIndex();
            var jx = tcb.NewIndexRange(A.Dims - 1);
            
            // general affine transformation
            tcb.Add(res[i].AssignSum(A[i, jx] * in[jx] + b[i]]));

            // 'F' is sugar the lib of float -> float functions
            tcb.Add(res[i].Assign(F.ReLU(res[i])));
        }
    )
}
```

A tensor comprehension (or just comprehension) operates in two distinct stages. First, it emits constraints on tensor dimensions. Second, it builds the the tensor comprehension _per se_.

The _builder_ produces a list of statements, inspired by the _Facebook Tensor Comprehensions_. At this point of the calculation, all tensor dimensions are known. This property facilitates writing logic over varying number of indices.

## Model persistence and check-pointing

The purpose of `TensorContext` is to allow a compute graph to be gracefully persisted and re-loaded afterward. This feature is desirable in order to perform _check-points_ which are needed when very long computations are involved.

All `Tensor` allocations are performed through the `TensorContext` which assign a unique identifier to each tensor. The unicity is only guaranteed within the scope of the context. A naïve serialization strategy can be written:

```
StreamWriter writer = ...; // snipped
ComputeGraph cg = ...; // snipped
writer.Write(cg.Parameters.Count)
foreach(var (idx, nda) in cg.Parameters)
{
    writer.Write(idx);
    writer.Write(nda);
}
```

Then, from the deserialization side, it would be:

```
TensorGraph tg = ...; // snipped
StreamReader reader = ...; // snipped
var dic = new Dictionary<int, Ndarray>();
var count = reader.ReadInt32();
for(var i = 0; i < count; i++)
{
    var idx = reader.ReadInt32();
    var nda = reader.ReadNdarray();
    dic.Add(idx, nda);
}
var cg = tg.Compile(dic);
```

We do not want to _force_ the client to serialize the tensor graph itself. As the client will also be running .NET, the client can re-instantiate the tensor graph, reloading only the parameter tensors. The only angle needed to make this work is to have a deterministic way to identify tensors when generating the tensor graph.

This approach removes entire class of versioning problems, as the serialization of the tensor graph is almost akin to the serialization of VM assembly.
