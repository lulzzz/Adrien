module Adrien.Derivatives

open System.Numerics;

type numeric = float32
type vector = numeric[]
type tensor = Tensor<numeric>

(* Scalar or vector or tensor numeric type*)
type A = 
    | Scalar of numeric
    | Vector of vector 
    | Tensor of tensor
    | Derivative of primal : A * derivative: A * tag: uint32 //forward derivative consisting of primal function, tangent, tag  
    member a.Zero = 
        match a with
        | Scalar _ -> A.Scalar 0.0f
        | Vector v -> A.Vector (Array.zeroCreate v.Rank)
        | Tensor t -> A.Tensor (Tensor.CreateIdentity(t.Rank, true, 0.0f))
        | Derivative(p, _, _) -> p.Zero

    member a.Rank = 
        match a with
        | Scalar _ -> 1
        | Vector v -> v.Rank
        | Tensor t -> t.Rank

    member a.Primal =
        match a with
        | Scalar _ -> a
        | Vector _ -> a
        | Tensor _ -> a
        | Derivative(p, _, _) -> p
    
    member a.Tangent =
        match a with
        | Scalar _ -> a.Zero
        | Vector v -> a.Zero
        | Tensor _ -> a.Zero
        | Derivative(_, d, _) -> d
        
    
and Op =
    // Scalar-valued operations
    | Add                  of A * A
    | Add_Cons             of A
    | Sub                  of A * A
    | Sub_Cons             of A
    | Mul                  of A * A
    | Mul_Cons             of A 
    | Pow                  of A * A
    | Pow_Cons             of A
    | Log                  of A
    | Log10                of A
    | Exp                  of A
    | Sin                  of A
    | Cos                  of A
    | Tan                  of A
    | Neg                  of A
    | Sqrt                 of A
    | Sinh                 of A
    | Cosh                 of A
    | Tanh                 of A
    | Asin                 of A
    | Acos                 of A
    | Atan                 of A
    | Abs                  of A
    | Sign                 of A
    | Aloor                of A
    | Ceil                 of A
    | Round                of A
    | ReLU                 of A
    | Sigmoid              of A

    // Vector-valued operations
     
    // Matrix-valued operations
    
    | Noop


let rec Zero f:A =
    match f with
        | Scalar _ -> A.Scalar 0.0f
        | Vector v -> A.Vector (Array.zeroCreate v.Rank)
        | Tensor t -> A.Tensor (Tensor.CreateIdentity(t.Rank, true, 0.0f))
        | Derivative(p, _, _) -> Zero p



