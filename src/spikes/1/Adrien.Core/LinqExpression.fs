module Adrien.LinqExpression

open System.Collections
open System.Linq.Expressions
open System.Reflection

type LinqExpression = Expression

let (|ConstantExpression|_|) (x:LinqExpression) = 
    if (x :? ConstantExpression) 
    then 
        let c = (x :?> ConstantExpression) in Some (c)
    else None

let (|Float32Expression|) (x:ConstantExpression) =
    match x.Type with
    | t when t = typeof<System.Single> -> Float32Expression
    | _ -> failwith "Unknown constant expression"

let (|UnaryExpression|_|) (x:LinqExpression) = 
    if (x :? UnaryExpression) 
    then 
        let ue = (x :?> UnaryExpression) in Some (ue)
    else None

let (|BinaryExpression|_|) (x:LinqExpression) = 
    if (x :? BinaryExpression) 
    then 
        let be = (x :?> BinaryExpression) in Some (be)
    else None

let (|PlusExpression|NegateExpression|OtherUnaryExpression|) (x:UnaryExpression) =       
    match x.NodeType with
    | ExpressionType.UnaryPlus -> PlusExpression
    | ExpressionType.Negate -> NegateExpression
    | _ -> OtherUnaryExpression

let (|AddExpression|SubtractExpression|MultiplyExpression|DivideExpression|EqualExpression|OtherBinaryExpression|) (x:BinaryExpression) =       
    match x.NodeType with
    | ExpressionType.Add -> AddExpression
    | ExpressionType.Subtract -> SubtractExpression
    | ExpressionType.Multiply -> MultiplyExpression
    | ExpressionType.Divide -> DivideExpression
    | ExpressionType.Equal -> EqualExpression
    | _ -> OtherBinaryExpression
 
