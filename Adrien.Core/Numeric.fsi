module Adrien.Numeric

open System.Numerics

type Numeric
type Op
type UnaryOp
type BinaryOp

val scalar : float32 -> Numeric
val (+) : Numeric -> Numeric -> BinaryOp
//val vector : float32[] -> Numeric 
