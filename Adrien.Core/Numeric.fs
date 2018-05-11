module Adrien.Numeric

open System.Numerics

type Numeric = N of Tensor<float32>
 
let scalar(n:float32) = N(Tensor.CreateIdentity(1, true, n)) 

let vector(n:float32[]) = N(Tensor.CreateIdentity(1, true, 0.0f)) 