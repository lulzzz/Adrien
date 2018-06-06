#r @"bin\Debug\netstandard2.0\Adrien.dll"

open Adrien.Numeric
open Adrien.Expression
open Adrien.Tree

(*c4 = sin c1;

let f x = sin x + cos x + constant 0.44f 

//tree f;;

let g x (y:Expression) = sin (x * y) + cos y + c3

derivative f;;
//let c x = sin x


//tree g;;

*)
//let h = sin c2
//h;;
//let t =  sin(c1 * c2 + c3) 
//let z x = x * constant 44.0f + t

//let g x = f
//composite g |> tree

//let f x = constant 0.44f +  sin x;

//let s1 = sin (constant 0.5f)

//derivative s1;;

//tree s1;;

let c:Expression = sin (constant 0.4f)

primal c

derivative c;





