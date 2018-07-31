# Adrien Implementation Notes


## Goals

The goals of Adrien are: 

* Provide a C# environment for tensor computation using reverse-mode automatic differentiation on tensor kernels. 
* Define an internal C# 7 DSL for constructing tensor comprehensions and compiling them into C# methods that can be 
use from any C# code .
* Use native tensor kernel compilers like PlaidML via plugins for high performance tensor computations.


## Solution structure
* [Adrien.Base](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Base): Contains base interfaces and 
abstract classes for the Adrien core classes and backend plugins.
* [Adrien.Core](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core): Contains the Adrien core classes:
  * [Notation](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Notation)
  * [Expressions]((https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Expressions))
  * [Trees]((https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Trees))
  * [Compiler](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Compiler)
  * [Diagrams](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Core/Diagrams)
* [Adrien.Bindings](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Bindings): Generates the C# bindings
to native libraries required by Adrien's core and backends.
* [Adrien.Tests](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Tests): Unit tests for each 
individual component of Adrien.
* [Adrien.Compiler.PlaidML](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/Adrien.Compiler.PlaidML): Source code
for the PlaidML tensor kernel compiler backend.
* [NativeLibs](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/NativeLibs): Contains Nuget packages with 
platform-speciic native library dependencies.
* [PythonLibs](https://github.com/Lokad/Adrien/tree/master/src/spikes/2/PythonLibs): Contains Python API projects for
libraries like PlaidML that serve as documentation and references for the C# implementations.


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
the vector `x` and scalar parameters `m`,`n`. More examples can be found in the 
[unit-tests](https://github.com/Lokad/Adrien/blob/master/src/spikes/2/Adrien.Tests/NotationTests.cs).

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

### Automatic Name Generation

```
// Construct three 4x3 tensors with auto-generated tensor and index names. Auto-generated tensor names 
// start with A and continue alphabetically. Auto-generated index names start with "i".

var (A, B, C) = Tensor.TwoD((4, 3), out Index i, out Index j).Three();

//Tensor names will be generated consecutively as "M1", "M2", "M3"
var (M1, M2, M3) = Tensor.ThreeD("M1", (2, 2, 2)).Three();
```

### Tensor Operations

The notation supports two kinds of tensor operations: element-wise (or [point-wise](https://en.wikipedia.org/wiki/Pointwise#Pointwise_operations)) 
operations and [contraction](http://mathworld.wolfram.com/TensorContraction.html) operations. Tensor expressions 
by default are element-wise: all the standard algebraic operations like +, -, *, / are element-wise.

### Element-wise Operations
```
//Define vectors and scalars
var (x, ypred, yactual, yerror, yloss) = new Vector(5, out Index i).Five("x", "ypred", "yactual", "yerror", "yloss");
var (a, b) = new Scalar().Two("a", "b");

//Define ypred and yerror as tensor expressions using alegebraic operators
ypred[x] = a * x + b;
yerror[ypred, yactual] = Pow2[yactual - ypred];

```

### Contraction Operations
Contraction operations are constructed using 
[Einstein summation notation](http://mathworld.wolfram.com/EinsteinSummation.html):
```
var (A, B, C) = Tensor.TwoD("A", (4,3), "a", out Index a, out Index b).Three();
C[a,b] = B[a,b] * C[b,a];
```
Each contraction operation is represented using a `Tensor` variable and one or more `Index` variable. In the above
snippet the tensor variable `C` is defined as the output of a matrix multiplication operation using the summation notation.

## Expressions
Tensor expressions are built up using the `Tensor` and operation types which use .NET LINQ expressions to create an
AST-like structure for tensor expressions. The final Linq expression is then converted to an Adrien `ExpressionTree`
which is an independent binary tree structure that can be manipulated from C# (or F#) without referencing LINQ classes.

## Expressions Trees
Adrien expression trees are bipartite acyclic graphs with two types of nodes: 
[Values](https://github.com/Lokad/Adrien/blob/master/src/spikes/2/Adrien.Core/Trees/ValueNode.cs) and 
[Operators](https://github.com/Lokad/Adrien/blob/master/src/spikes/2/Adrien.Core/Trees/OperatorNode.cs). Expression 
trees represent computations graphs for a single tensor kernel.


## Variables
Adrien Variables bind symbolic tensor expressions to data in memory. Each tensor variable has a `Var<T>` method 
that accepts data from .NET arrays or alternatively `Memory<T>` references. 

## Kernels
Kernels are units of compilations that bind tensor expressions to input and output data. Kernels are compiled into
C# lambda methods.

```
var (x, y) = new Vector(5).Two("x", "y");
var (a, b) = new Scalar().Two("a","b");
y[x] = a * x + b;
TileCompiler compiler = new TileCompiler();

k = new Kernel<int>(y, a * x + b, compiler);

            
var vy = y.Var(new int[5]);
var vx = x.Var(1, 2, 3, 4, 5);
var va = a.Var(2);
var vb = b.Var(1);
            
var predict = k.Func3;
var r = predict(3, new int[5] { 2, 4, 6, 8, 10 }, 2);
```
