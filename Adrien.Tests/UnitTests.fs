module UnitTest 

open Xunit
open Adrien.Numeric
open Adrien.Expression

[<Fact>]
let ``Can construct`` () =
    let r = constant 4.4f
    let s = constant 3.0f
    let m = r + s
    Assert.Equal(true, true)
