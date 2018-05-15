module Adrien.Numeric

(**
# First-level heading
Some more documentation using `Markdown`.
*)
type Numeric = 
    {   Shape : Shape
        Format : Format
        Data : obj 
        Op: Op option
        Left: Numeric option
        Right: Numeric option
    }
    static member UnaryOp(a:Numeric, op:Op) = {Shape = a.Shape; Format = a.Format; Data = None; Op = Some op; Left = Some a; Right = None}

    static member BinaryOp(a:Numeric, b:Numeric, op:Op) = {Shape = a.Shape; Format = a.Format; Data = None; Op = Some op; Left = Some a; Right = Some b}

    static member (~-)  (a:Numeric)  =  Numeric.UnaryOp(a, Op.SubCons)
    static member (~+)  (a:Numeric)  =  Numeric.UnaryOp(a, Op.AddCons)

    static member (*)  (a:Numeric, b:Numeric)  =  Numeric.BinaryOp(a, b, Op.Mul)
    static member (/)  (a:Numeric, b:Numeric)  =  Numeric.BinaryOp(a, b, Op.Div)
    static member (+)  (a:Numeric, b:Numeric)  =  Numeric.BinaryOp(a, b, Op.Add) 
    static member (-)  (a:Numeric, b:Numeric)  =  Numeric.BinaryOp(a, b, Op.Sub)
    
    static member Sin(a:Numeric) = Numeric.UnaryOp(a, Op.Sin)
    static member Cos(a:Numeric) = Numeric.UnaryOp(a, Op.Cos)
  
and Shape =
    | Scalar
    | Vector
    | Matrix
    | Tensor
    | Symbol

and Format =
    | Float32 
    | Float64 
    | Int16
    | Int32
    | Nan

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


type VectorArray<'T> = 'T[]
type MatrixArray<'T> = 'T[,]

let Zero = { Shape = Symbol; Format = Float32; Data = 0.0f; Op = None; Left = None; Right = None}

let One = { Shape = Symbol; Format = Float32; Data = 1.0f; Op = None; Left = None; Right = None}

let Nin = { Shape = Symbol; Format = Nan; Data = "Nin"; Op = None; Left = None; Right = None}

let scalar(n:float32) = { Shape = Scalar; Format = Float32; Data = n; Op = None; Left = None; Right = None; }

let vector(n:VectorArray<float32>) = { Shape = Vector; Format = Float32; Data = n; Op = None; Left = None; Right = None; }

let matrix(n:MatrixArray<float32>) = { Shape = Matrix; Format = Format.Float32; Data = n; Op = None; Left = None; Right = None; }



(*
let eval (n:Numeric) =
        match n.Shape with
            | Scalar -> match n.Format with
                | Float32 -> match n.Op with  
                    | Some Op.Mul -> b.ScalarMultiply(n.Left, n.Right)
                    *)