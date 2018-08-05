# Adrien.Notation

The `Notation` namespace is introduces a DSL-in-C# intended for tensor
expressions - sometimes alternatively called tensor comprehensions. This
namespace focuses on providing an abstraction of the numeric operations
on tensors, not on executing those operations.

     var (A, B, C) = Tensor.ThreeD("A", (2, 2, 2), "a", 
	                     out Index i, out Index j, out Index k).Three();
     C[i, k] = A[i, j] * B[j, k];

The snippet above illustrates how a tensor `C` is built as a matrix
multiplication from `A` and `B` while abstracting away the indices.
