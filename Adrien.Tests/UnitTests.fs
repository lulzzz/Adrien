module UnitTest 

open Xunit
open Adrien.Numeric

[<Fact>]
let ``Can construct`` () =
    let r = scalar 4.4f
    let s = scalar 3.0f
    let m = r + s
    Assert.True(true)
