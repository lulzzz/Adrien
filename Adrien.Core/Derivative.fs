module Adrien.Derivative

open Adrien.Numeric

type Derivative =
    | Const of Numeric
    | Derivative of f: Derivative * df: Derivative * tag: uint32 //Forward mode derivative 

    static member Zero = Derivative.Const(scalar 0.0f)

     //The derivative of f(g(x)) wrt x is f'(g(x)) * g'(x) or df/dg * dg/dx
    member inline a.UnaryOp (ff, fd, df) =
        match a with
        | Const x  -> Const(ff(x))
        | Derivative(x, dx, tag) -> let cp = fd(x) in Derivative(cp, df(cp, x, dx), tag)
    
    member inline a.BinaryOp(b, ff, fd, df_da, df_db, df_dab) =
        match a with
        | Const x ->
            match b with
            | Const y    ->  Const(ff(x, y))
            | Derivative(y, dy, ytag) -> let cp = fd(a, y) in Derivative(cp, df_db(cp, y, dy), ytag)
         
        | Derivative(x, dx, xtag) ->
            match b with
            | Const _  -> let cp = fd(x, b) in Derivative(cp, df_da(cp, x, dx), xtag)
            | Derivative(y, dy, ytag) ->
                match compare xtag ytag with
                | 0                  -> let cp = fd(x, y) in Derivative(cp, df_dab(cp, x, dx, y, dy), xtag) // ai = bi
                | -1                 -> let cp = fd(a, y) in Derivative(cp, df_db(cp, y, dy), ytag) // ai < bi
                | _ -> let cp = fd(x, b) in Derivative(cp, df_da(cp, y, dy), ytag) // ai > bi

    member d.Primal =
        match d with
        | Const _ -> d
        | Derivative(f, _, _) -> f

    member d.Differential =
        match d with
        | Const _ -> Derivative.Zero
        | Derivative(_, df, _) -> df
    
    
    static member (+) (a:Derivative, b:Derivative) =
        let inline ff(a, b) = a + b
        let inline fd(a, b) = a + b
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = bt
        let inline df_dab(cp, ap, at, bp, bt) = at + bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (-) (a:Derivative, b:Derivative) =
        let inline ff(a, b) = a - b
        let inline fd(a, b) = (a - b)
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = -bt
        let inline df_dab(cp, ap, at, bp, bt) = at - bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (*) (a:Derivative, b:Derivative) =
        let inline ff(a, b) = a * b
        let inline fd(a, b) = a * b
        let inline df_da(cp, ap, at) = at * b
        let inline df_db(cp, bp, bt) = a * bt
        let inline df_dab(cp, ap, at, bp, bt) = at * bp + ap * bt
        a.BinaryOp(b, ff, fd, df_da, df_db, df_dab)

    static member (~-) (a:Derivative) =
        let inline ff(a) = -a
        let inline fd(a) = -a
        let inline df(cp, ap, at) = -at
        a.UnaryOp(ff, fd, df)

    
    static member Sin (a:Derivative) =
        let inline ff(a) = sin a
        let inline fd(a) = sin a
        let inline df(cp:Derivative, ap:Derivative, at:Derivative) = at * cos ap
        a.UnaryOp(ff, fd, df)

    static member Cos (a:Derivative) =
        let inline ff(a) = cos a
        let inline fd(a) = cos a
        let inline df(cp, ap, at) = -at * sin ap
        a.UnaryOp(ff, fd, df)
        




 
    
        


