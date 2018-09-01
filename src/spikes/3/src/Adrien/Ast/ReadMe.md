# Abstract Syntax Tree (AST)

The AST is intended to the compilation target for a numeric backend of Adrien.

The AST of Adrien reflects a language constructed from a direct acyclic graph 
of tiles, and where each tile is a list of statements that can be compiled 
as an algebra of tensors.

The objects of this namespace are immutable, except for their geometric
properties where they are monotonous; those properties can be set once, but 
never modified afterward.
