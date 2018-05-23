module Adrien.Expression

open Adrien.Numeric

type Expression =
    | Constant of Numeric
    | Expression of f: Expression * df: Expression * tag: uint32 //Forward mode derivative 
    | Function of (Expression -> Expression)
    | CFunction of (Expression -> Expression -> Expression)

    static member Zero = scalar 0.0f |> Constant

let internal V = Var |> Constant

//The derivative of f(g(x)) wrt x is f'(g(x)) * g'(x) or df/dg * dg/dx
let rec unary a ff fd df =
    match a with
    | Constant x  -> ff x |> Constant
    | Expression(a, da, tag) -> let cp = fd(a) in Expression(cp, df(cp, a, da), tag)
    | Function f -> let v = f(V) in unary v ff fd df
    | CFunction gf -> let v2 = gf(V) in unary (v2 |> Expression.Function) ff fd df

let rec binary a b ff fd df_da df_db df_dab =
    match a with
    | Constant x ->
        match b with
        | Constant y ->  ff(x, y) |> Constant
        | Expression(y, dy, ytag) -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag)
        | Function f -> let v = f(V) in binary a v ff fd df_da df_db df_dab
        | CFunction gf -> let v2 = gf(V) in binary a (v2 |> Expression.Function) ff fd df_da df_db df_dab
         
    | Expression(x, dx, xtag) ->
        match b with
        | Constant _  -> let cp = fd(x, b) in Expression(cp, df_da(cp, x, dx), xtag)
        | Expression(y, dy, ytag) ->
            match compare xtag ytag with
            | 0 -> let cp = fd(x, y) in Expression(cp, df_dab(cp, x, dx, y, dy), xtag) // ai = bi
            | -1                 -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag) // ai < bi
            | _ -> let cp = fd(x, b) in Expression(cp, df_da(cp, y, dy), ytag) // ai > bi
        | Function f -> let v = f(V) in binary v b ff fd df_da df_db df_dab
        | CFunction gf -> let v2 = gf(V) in binary (v2 |> Expression.Function) b ff fd df_da df_db df_dab


    | Function f -> let v = f(V) in binary v b ff fd df_da df_db df_dab

    | CFunction gf -> let v2 = gf(V) in binary (v2 |> Expression.Function) b ff fd df_da df_db df_dab

let rec primal d =
    match d with
    | Constant _ -> d
    | Expression(f, _, _) -> f
    | Function f -> let v = f(V) in primal v
    | CFunction gf -> let v2 = gf(V) in primal (v2 |> Expression.Function)

let rec derivative d =
    match d with
    | Constant _ -> Expression.Zero
    | Expression(_, df, _) -> df
    | Function f -> let v = f(V) in derivative v
    | CFunction gf -> let v2 = gf(V) in derivative (v2 |> Expression.Function)

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
    | :? float32 as x -> scalar x  |> Constant
    | :? VectorArray<float32> as x -> vector x  |> Constant
    | :? MatrixArray<float32> as x -> matrix x  |> Constant
    | _ -> failwith "Unknown constant expression."
    
        


