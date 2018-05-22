module Adrien.Expression

open Adrien.Numeric

type Expression =
    | Expression of Numeric
    | Derivative of f: Expression * df: Expression * tag: uint32 //Forward mode derivative 

    static member Zero = scalar 0.0f |> Expression

     //The derivative of f(g(x)) wrt x is f'(g(x)) * g'(x) or df/dg * dg/dx
type A = Expression

let unary a ff fd df =
    match a with
    | Expression x  -> ff x |> Expression
    | Derivative(a, da, tag) -> let cp = fd(a) in Derivative(cp, df(cp, a, da), tag)
    
let binary a b ff fd df_da df_db df_dab =
    match a with
    | Expression x ->
        match b with
        | Expression y ->  ff(x, y) |> Expression
        | Derivative(y, dy, ytag) -> let cp = fd(a, y) in Derivative(cp, df_db(cp, y, dy), ytag)
         
    | Derivative(x, dx, xtag) ->
        match b with
        | Expression _  -> let cp = fd(x, b) in Derivative(cp, df_da(cp, x, dx), xtag)
        | Derivative(y, dy, ytag) ->
            match compare xtag ytag with
            | 0 -> let cp = fd(x, y) in Derivative(cp, df_dab(cp, x, dx, y, dy), xtag) // ai = bi
            | -1                 -> let cp = fd(a, y) in Derivative(cp, df_db(cp, y, dy), ytag) // ai < bi
            | _ -> let cp = fd(x, b) in Derivative(cp, df_da(cp, y, dy), ytag) // ai > bi

let primal d =
    match d with
    | Expression _ -> d
    | Derivative(f, _, _) -> f

let derivative d =
    match d with
    | Expression _ -> Expression.Zero
    | Derivative(_, df, _) -> df

type Expression with
        
    static member (+) (a:Expression, b:Expression) =
        let inline ff(a, b) = a + b
        let inline fd(a, b) = a + b
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = bt
        let inline df_dab(cp, ap, at, bp, bt) = at + bt
        binary a b ff fd df_da df_db df_dab

    static member (-) (a:Expression, b:Expression) =
        let inline ff(a, b) = a - b
        let inline fd(a, b) = (a - b)
        let inline df_da(cp, ap, at) = at
        let inline df_db(cp, bp, bt) = -bt
        let inline df_dab(cp, ap, at, bp, bt) = at - bt
        binary a b ff fd df_da df_db df_dab

    static member (*) (a:Expression, b:Expression) =
        let inline ff(a, b) = a * b
        let inline fd(a, b) = a * b
        let inline df_da(cp, ap, at) = at * b
        let inline df_db(cp, bp, bt) = a * bt
        let inline df_dab(cp, ap, at, bp, bt) = at * bp + ap * bt
        binary a b ff fd df_da df_db df_dab

    static member (~-) (a:Expression) =
        let inline ff(a) = -a
        let inline fd(a) = -a
        let inline df(cp, ap, at) = -at
        unary a ff fd df

    static member Sin (a:Expression) =
        let inline ff(a) = sin a
        let inline fd(a) = sin a
        let inline df(cp:Expression, ap:Expression, at:Expression) = at * cos ap
        unary a ff fd df

    static member Cos (a:Expression) =
        let inline ff(a) = cos a
        let inline fd(a) = cos a
        let inline df(cp, ap, at) = -at * sin ap
        unary a ff fd df
    
let constant(n : obj) = 
    match n with
    | :? float32 as x -> scalar x  |> Expression
    | :? VectorArray<float32> as x -> vector x  |> Expression
    | :? MatrixArray<float32> as x -> matrix x  |> Expression
    | _ -> failwith "Unknown constant expression."
    
        


