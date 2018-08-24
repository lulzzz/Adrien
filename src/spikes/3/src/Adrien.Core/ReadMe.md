# Adrien.Core


## Abstraction levels

The library can be seen as an DSL-in-C# for differentiable programming.
The computational networks have three levels of abstractions:

1. Symbolic: intended for high-level network definition.
2. Geometric: indended for most network transformations.
3. Numeric: intended for actual numerical computations.


                |  Symbolic | Geometric | Numeric
------------------------------------------------------
Variable        | Symbol    | Tensor    | NDArray
Compute Unit    | Flow      | Tile      | Kernel
Compute Network | FlowGraph | TileGraph | KernelGraph

A symbol does not have a shape, only constraints, referred as _beams_ 
which allow the shape (rank and dimensions) to be inferred. The symbolic
level is intended to facilitate the definition of the network, which
can involve high-order functional operator.

A tensor is fully defined both in shape and type. Most network transformations
such as reverse differentiation, or minibatch augmentation are intended to
be performed at the geometric level.

A NDarray is fully defined in shape, type and numerical values. Operations on
those arrays are intended to be delegated to specialized hardware such as
a GPU or a TPU.


## Basic vs Fluent APIs

The DSL-like APIs for differential programming arereferred as _fluent_.
Those APIs are intended for inline compact notations. Those API somewhat
stretches the capabilities of the C# syntax, are isolated as an overlay
of the more basic APIs.
