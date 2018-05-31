module Adrien.Util

open System.Linq.Expressions
open System.Text.RegularExpressions
open Microsoft.FSharp.Linq.RuntimeHelpers

let (|RegexMatch|_|) input pattern group =
   let m = Regex.Match(input, pattern) 
   if m.Success then
    if group < m.Groups.Count then
        Some m.Groups.[group].Value
    else None
   else None
    
let toExpression (``f# lambda`` : Quotations.Expr<'a>) =
    ``f# lambda``
    |> LeafExpressionConverter.QuotationToExpression 
    |> unbox<Expression<'a>>