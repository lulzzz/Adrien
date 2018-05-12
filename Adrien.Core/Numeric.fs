module Adrien.Numeric

open System.Numerics

type Shape =
    | Scalar
    | Vector
    | Matrix

type Number =
    | Float32
    | Float64
    | Int16
    | UInt16
    
type Numeric = 
    {   
        Shape : Shape
        Number : Number;
    }

type Op =
    | Log
    | Log10
    | Add
    | Sub
    | Mul
    | Div

type UnaryOp = 
    {
        left: Numeric
        op: Op
    }

type BinaryOp = 
    {
        left: Numeric
        right: Numeric
        op: Op
    }
    
type Numeric with
    
    
    static member (-) (a:Numeric, b:Numeric) = {left = a; right = b; op = Op.Sub }


let scalar(n:float32) =   
        {
            Shape = Shape.Scalar; 
            Number = Float32;
        }

let (+) a b = {left = a; right = b;  op = Op.Add}





    