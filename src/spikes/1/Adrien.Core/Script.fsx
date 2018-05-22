#r @"bin\Debug\netstandard2.0\Adrien.dll"

open Adrien.Numeric
open Adrien.Expression
open Adrien.Tree

let s1 = scalar 4.4f
let c1 = constant 4.4f;
let c2 = constant 6.4f;
let c3 = constant 8.4f;
let c4 = sin c1;
//let f x:A = sin x + cos x + constant 0.44



 
//let e = scalar 4.4f * vector([|0.9f|])

//let o = constant t * constant e
//o;;

let t =  sin(c1 * c2 + c3) |> tree

 





