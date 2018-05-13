module Adrien.Numeric


type Numeric = 
    {   Shape : Shape
        Format : Format
        Data : obj
        Op: Op option
        Left: Numeric option
        Right: Numeric option
    }

    static member Zero = { Shape = Scalar; Format = Float32; Data = 0.0f; Op = None; Left = None; Right = None}

    static member UnaryExp(a:Numeric, op:Op) = {Shape = a.Shape; Format = a.Format; Data = null; Op = Some op; Left = Some a; Right = None}

    static member BinaryExp(a:Numeric, b:Numeric, op:Op) = {Shape = a.Shape; Format = a.Format; Data = null; Op = Some op; Left = Some a; Right = Some b}

    static member (~-)  (a:Numeric)  =  Numeric.UnaryExp(a, Op.SubCons)
    static member (~+)  (a:Numeric)  =  Numeric.UnaryExp(a, Op.AddCons)

    static member (*)  (a:Numeric, b:Numeric)  =  Numeric.BinaryExp(a, b, Op.Mul)
    static member (/)  (a:Numeric, b:Numeric)  =  Numeric.BinaryExp(a, b, Op.Div)
    static member (+)  (a:Numeric, b:Numeric)  =  Numeric.BinaryExp(a, b, Op.Add) 
    static member (-)  (a:Numeric, b:Numeric)  =  Numeric.BinaryExp(a, b, Op.Sub)
    
    static member Sin(a:Numeric) = Numeric.UnaryExp(a, Op.Sin)
    static member Cos(a:Numeric) = Numeric.UnaryExp(a, Op.Cos)
  
and Shape =
    | Scalar
    | Vector
    | Matrix
    | Tensor

and Format =
    | Float32 
    | Float64 
    | Int16
    | Int32

and Op =
    | Log
    | Log10
    | Add
    | AddCons
    | Sub
    | SubCons
    | Mul
    | Div
    | Sin
    | Cos


and UnaryOp = 
    {
        operand: Numeric
        op: Op
    }

and BinaryOp = 
    {
        left: Numeric
        right: Numeric
        op: Op
    }



let scalar(n:float32)         = { Shape = Scalar; Format = Float32; Data = n; Op = None; Left = None; Right = None; }

let vector(n:float32[])       = { Shape = Vector; Format = Float32; Data = n; Op = None; Left = None; Right = None; }

let matrix(n:float32[][])     = { Shape = Matrix; Format = Format.Float32; Data = n; Op = None; Left = None; Right = None; }



(*
let eval (n:Numeric) =
        match n.Shape with
            | Scalar -> match n.Format with
                | Float32 -> match n.Op with  
                    | Some Op.Mul -> b.ScalarMultiply(n.Left, n.Right)
                    *)