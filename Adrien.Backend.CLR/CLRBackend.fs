module Adrien.CLRBackend

open Adrien.Backend

type CLRScalarBackend()  = 
    interface ScalarBackend<float32> with
        member b.Multiply(left: float32, right:float32) = left * right

 let CLR:Backend<float32, float32, float32, float32> = {Scalar = CLRScalarBackend()}  