# Adrien Implementation Notes


## Goals

The goals of Adrien are: 
Provide a C# environment

* Familiar syntax to NumPy users


## High-level design
Notations
Expression Trees: A tree data structure for representing tensor expressions defined by the Notation
Kernels: Bin
Variables: Bind input and output 
Compiler
Runnables



## Notation
Adrien's [Notation](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Notation) classes take advantage of the latest C# features to provide a concise, efficient and expressive 
notation for working with tensor comprehensions. The notation classes override the C# array index `[]` operator to
denotes mathematical operations on tensors as opposed to language level C# operations. E.g

```
var (x, y) = new Vector("x", 2).Two();
var (m,n) = new Scalar("m").Two();
y[x] = m * x + n;
``` 

In the above three lines we define 2 vectors, 2 scalars, and define the vector `y` to be an element-wise function of 
the vector `x` and scalar parameters `m`,`n`.

### Automatic name generation

```
// Construct three 4x3 tensors with auto-generated tensor and index names. Auto-generated tensor names 
// start with A and continue alphabetically. Auto-generated index names start with "i".

var (A, B, C) = Tensor.TwoD((4, 3), out Index i, out Index j).Three();

//Tensor names will be generated consecutively as "M1", "M2", "M3"
var (M1, M2, M3) = Tensor.ThreeD("M1", (2, 2, 2)).Three();
```
### Tensor Construction

```
//Construct a 2D tensor with dimensions 7,7 named A with index variables a,b.
Tensor A = Tensor.TwoD("A", (7,7), "a", out Index a, out Index b);
A[a,b] = ...

//Construct a 3D tensor named B with an index set named ijk. 
var B = Tensor.ThreeD("B", (5, 6, 7), "i", out var ijk);
B[ijk] = ...

//Deconstruct the index set ijk
var (i, j, k) = ijk;
B[i] = ...

//Use fluent construction syntax for 3 2-D tensors. E has the same dimensions as D.
Tensor D = Tensor.TwoD("D", (11, 12))
    .With(out Tensor E)
    .With(out Tensor F, 4, 3);

//Use tuple syntax for creating 3 2x2x2 tensors
 var (H, I, J) = Tensor.ThreeD("H", (2, 2, 2)).Three();

//Use specific tensor names with tuple syntax
var (M1, M2, M3) = Tensor.ThreeD((2, 2, 2)).Three("M1", "M2", "M3");
```


The square brackets syntax is similar to Mathematica's syntax for 
[matrices](http://reference.wolfram.com/language/tutorial/BasicMatrixOperations.html) and 
[tensors](http://reference.wolfram.com/language/tutorial/Tensors.html).

## Tensor Operations

The notation supports two kinds of tensor operations: element-wise (or [point-wise](https://en.wikipedia.org/wiki/Pointwise#Pointwise_operations)) 
operations and [contraction](http://mathworld.wolfram.com/TensorContraction.html) operations. Tensor expressions 
by default are element-wise: all the standard algebraic operations like +, -, *, / are element-wise.

### Element-wise operation
```

//Define 
var (x, ypred, yactual, yerror, yloss) = new Vector(5, out Index i).Five("x", "ypred", "yactual", "yerror", "yloss");
var (a, b) = new Scalar().Two("a", "b");

//Define ypred and yerror as tensor expressions using alegebraic operators
ypred[x] = a * x + b;
yerror[ypred, yactual] = Pow2[yactual - ypred];

```

### Contraction operations
Tensor contractions are aggegrations
## Expression Trees
Adrien expression trees are bipartite acyclic graphs with two types of nodes: 
[Values](https://github.com/Lokad/Adrien/blob/master/src/spikes/2/Adrien.Core/Trees/ValueNode.cs) and 
[Operators](https://github.com/Lokad/Adrien/blob/master/src/spikes/2/Adrien.Core/Trees/OperatorNode.cs). Expression 
trees represent computations graphs 

Linq exprssions are coverted into a gene

## Variables
Adrien Variables bind symbolic tensor expressions to data in memory. 

## Kernels
Kernels are units of compilations that bind tensor expressions to input and out 

## Compilers
Adrien compilers take kernels and compile them into executable C# functions 