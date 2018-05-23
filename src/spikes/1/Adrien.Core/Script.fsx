#r @"bin\Debug\netstandard2.0\Adrien.dll"

open Adrien.Numeric
open Adrien.Expression
open Adrien.Tree

let s1 = scalar 4.4f
let c1 = constant 4.4f;
let c2 = constant 6.4f;
let c3 = constant 8.4f;
let c4 = sin c1;
type A = Expression
let f x = sin x + cos x + constant 0.44f 
let z x = x * constant 44.0f

let t =  sin(c1 * c2 + c3) |> expr_tree

tree f 

let g x = f >> z

composite g |> tree





