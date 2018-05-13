module Adrien.Expression

open Adrien.Numeric

type Expression =
    | Const of Numeric
    | Expression of f: Expression * df: Expression * tag: uint32 //Forward mode derivative 

    static member Zero = Expression.Const(scalar 0.0f)

     //The derivative of f(g(x)) wrt x is f'(g(x)) * g'(x) or df/dg * dg/dx
    member inline a.UnaryOp (ff, fd, df) =
        match a with
        | Const x  -> Const(ff(x))
        | Expression(a, da, tag) -> let cp = fd(a) in Expression(cp, df(cp, a, da), tag)
    
    member inline a.BinaryOp(b, ff, fd, df_da, df_db, df_dab) =
        match a with
        | Const x ->
            match b with
            | Const y    ->  Const(ff(x, y))
            | Expression(y, dy, ytag) -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag)
         
        | Expression(x, dx, xtag) ->
            match b with
            | Const _  -> let cp = fd(x, b) in Expression(cp, df_da(cp, x, dx), xtag)
            | Expression(y, dy, ytag) ->
                match compare xtag ytag with
                | 0                  -> let cp = fd(x, y) in Expression(cp, df_dab(cp, x, dx, y, dy), xtag) // ai = bi
                | -1                 -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag) // ai < bi
                | _ -> let cp = fd(x, b) in Expression(cp, df_da(cp, y, dy), ytag) // ai > bi

    member d.Primal =
        match d with
        | Const _ -> d
        | Expression(f, _, _) -> f

    member d.Differential =
        match d with
        | Const _ -> Expression.Zero
        | Expression(_, df, _) -> df
    
    
    static member (+) (a:Expression, b:Expression) =
        let inline ff(a, b) = a + b
        let inline fd(a, b) = a + b
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = bt
        let inline df_dab(cp, ap, at, bp, bt) = at + bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (-) (a:Expression, b:Expression) =
        let inline ff(a, b) = a - b
        let inline fd(a, b) = (a - b)
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = -bt
        let inline df_dab(cp, ap, at, bp, bt) = at - bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (*) (a:Expression, b:Expression) =
        let inline ff(a, b) = a * b
        let inline fd(a, b) = a * b
        let inline df_da(cp, ap, at) = at * b
        let inline df_db(cp, bp, bt) = a * bt
        let inline df_dab(cp, ap, at, bp, bt) = at * bp + ap * bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (~-) (a:Expression) =
        let inline ff(a) = -a
        let inline fd(a) = -a
        let inline df(cp, ap, at) = -at
        a.UnaryOp(ff, fd, df)

    
    static member Sin (a:Expression) =
        let inline ff(a) = sin a
        let inline fd(a) = sin a
        let inline df(cp:Expression, ap:Expression, at:Expression) = at * cos ap
        a.UnaryOp(ff, fd, df)

    static member Cos (a:Expression) =
        let inline ff(a) = cos a
        let inline fd(a) = cos a
        let inline df(cp, ap, at) = -at * sin ap
        a.UnaryOp(ff, fd, df)
    
type A = Expression

let Const(n:Numeric)  = n|> Expression.Const

let constant(c:float32) = scalar c |> Expression.Const

 
    
        


