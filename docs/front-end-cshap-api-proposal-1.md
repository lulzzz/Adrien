# Front-end APIs for Adrien
> By Joannes Vermorel, May 2018

Status: EARLY DRAFT

This document is a tentative to define the overall look-and-feel of a C# front-end API for Adrien.

Todos:

* 4 tensor types: input, constant, flow, parameter
* 2-stage compilation (dims first, TC second)
* weight initialization
* rephrase "layers" as TC
* tensor comprehensions
* persisting model requires to stable indexing of tensors
* columnar data-feeding pattern with chunks
* dynamic generation of input datasets
* `Ndarray` with `Memory<float>` or `Span<float>`

The API differentiates the `Tensor` which as symbolic from from the `Ndarray` which is the numeric counterpart.

The base class `Tensor` is an untyped generic tensor; it is intended for a "programmatic" use case.

The `Tensor<D1, D2, D3>` generic descendants of `Tensor` are encoding the tensor dimensions through the generics. They lend themselves to some degree of type-inference support from C#.

```
// untyped generic tensor
class Tensor { }

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
        outputs: new[] {X4} 
    );

    var cg = tg.Compile(); // cg = compute graph

    // assuming proper data
    IEnumerable<MyInput> examples = ...; // snipped 
    
    // stream 'batches' of inputs
    var batch = new Minibatch(
        examples, 
        batchSize: 64,
        randomize: true);

    // TODO: missing the weight initialization

    // configuring the SGD
    var descent = SGD.RMSProp(cg);
    for(int i = 0; i < 1000; i++)
    {
        descent.Do(batch);
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

## Model persistence and check-pointing

The purpose of `TensorContext` is to allow a model to be gracefully persisted.
