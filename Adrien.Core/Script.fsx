#r @"bin\Debug\netstandard2.0\Adrien.dll"


open Adrien.Expression
open Adrien.Numeric

let f x:A = sin x + cos x + constant 0.44

f (constant 0.0f);;






