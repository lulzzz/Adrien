namespace Adrien.Backend

open Adrien.Backend

module CLR =

    type CLRScalarBackend()  = 
        interface ScalarBackend<float32> with
            member b.Multiply(left: float32, right:float32) = left * right

    let CLR:Backend<float32, obj, obj, obj> = {Scalar = CLRScalarBackend()}  