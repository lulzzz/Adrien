# Adrien Implementation Notes


## Goals

The goals of Adrien are:



Allow 
## Notation
Adrien's Notation classes take advantage the latest C# features to provide a concise, efficient and expressive notation for working with tensor
comprehensions.

### Automatic name generation

//
var A = Tensor.TwoD(4,5)

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


var (M1, M2, M3) = Tensor.ThreeD((2, 2, 2)).Three("M1", "M2", "M3");
```


The square brackets syntax is similar to Mathematica's syntax for 
[matrices](http://reference.wolfram.com/language/tutorial/BasicMatrixOperations.html) and 
[tensors](http://reference.wolfram.com/language/tutorial/Tensors.html).
### Defining



The notation supports two kinds of tensor operations: element-wise (or [point-wise](https://en.wikipedia.org/wiki/Pointwise#Pointwise_operations)) 
operations and contractions. Tensor expressions by default are element-wise: alll the standard algebraic

Element-wise operations


## Variables

Variables represent 2-way bindings between data in memory and symbolic tensor comprehensions created using the Notation
classes

## Expression Trees
Tensor 