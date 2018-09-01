# Fluent API

The purpose of the fluent API is to provide a more
idiomatic way of instantiating both tiles and graphes 
in C#.

The fluent API operates by composition (rather than 
inheritance) on top of the basic API of Adrien as this
approach offers more flexibility in introduce syntactic
sugars and similar syntax niceties.

Most object are named `FBar` as the fluent counterpart
of the original `Bar` object from the basic API.
