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

    static member (~-)  (a:Numeric)  =  (a, Op.SubCons) |> Numeric.UnaryOp
    static member (~+)  (a:Numeric)  =  (a, Op.AddCons) |> Numeric.UnaryOp

    static member (*)  (a:Numeric, b:Numeric)  =  (a, b, Op.Mul) |> Numeric.BinaryOp
    static member (/)  (a:Numeric, b:Numeric)  =  (a, b, Op.Div) |> Numeric.BinaryOp
    static member (+)  (a:Numeric, b:Numeric)  =  (a, b, Op.Add) |> Numeric.BinaryOp 
    static member (-)  (a:Numeric, b:Numeric)  =  (a, b, Op.Sub) |> Numeric.BinaryOp
    
    static member Sin(a:Numeric) = (a, Op.Sin) |> Numeric.UnaryOp
    static member Cos(a:Numeric) = (a, Op.Cos) |> Numeric.UnaryOp
  
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
   
    member op.isUnary = 
        match op with
        | Log | Log10 | AddCons | SubCons | Sin | Cos-> true
        | _ -> false

    member op.isBinary = 
        match op with
        | Add | Sub | Mul | Div -> true
        | _ -> false

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

let (|Unary|Binary|) (op:Op) = 
    if op.isUnary then Unary 
    else if op.isBinary then Binary
    else failwith "Unknown operation"
    
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