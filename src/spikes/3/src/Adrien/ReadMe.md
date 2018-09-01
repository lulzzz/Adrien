# Adrien

Adrien is an differentiable programming framework intended for .NET.

## Abstraction levels

The library can be seen as an DSL-in-C# for differentiable programming.
The programs have three levels of abstractions:

1. Symbolic: intended for high-level program definition.
2. Geometric: indended for most program transformations.
3. Numeric: intended for actual numerical computations.


                |  Symbolic | Geometric | Numeric
------------------------------------------------------
Variable        | Variable  | +Shape    | Tensor
Function        | Tile      | +Range    | Kernel
Compute unit    | Edge      |           | Operation
Program         | Graph     |           | Flow

A variable does not have a shape, only constraints, referred as _beams_ 
which allow the shape (rank and dimensions) to be inferred. The symbolic
level is intended to facilitate the definition of the program, which
can involve high-order functional operator.

Once the geometric inference has been performed, variables are fully
defined shape and type. Similarly, at the tile leve, once the geometric
inference has been performed, index ranges are known.

A tensor is fully defined in shape, type and numerical values. Operations on
those arrays are intended to be delegated to specialized hardware such as
a GPU or a TPU.


## Basic API vs Fluent APIs

The DSL-like APIs for differential programming are referred as _fluent_.
Those APIs are intended for inline compact notations. Those API somewhat
stretches the capabilities of the C# syntax, are isolated as an overlay
of the more basic APIs.

The basic API - as the name suggests - is intended for simplicity. It
decouples the intricacies of the frontend syntax from the compilation
task which converts a tile into a kernel.

## Numeric backend

A backend refers to an actual implementation of tensors and kernels.
Adrien is designed to allow such a backend to be plugged by providing
an implementation of `ITileCompiler`.
