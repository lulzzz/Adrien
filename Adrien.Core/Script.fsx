#r @"bin\Debug\netstandard2.0\Adrien.dll"


open Adrien.Expression
open Adrien.Numeric


let r = scalar 4.4f
let s = scalar 3.0f

let m = r + s

let v = 3 + 5


let f x:Expression = sin x + cos x


let g x:A = f(x) + constant 0.4f





