module Adrien.Expression

open Adrien.Numeric
open Adrien.Tagger

type IDerivable = interface end

type Expression =
    | Value of Numeric
    | Expression of f: Expression * df: Expression * tag: uint32 //Forward mode derivative 
    interface IDerivable
 
    static member Zero = scalar 0.0f |> Value

type Function =
    | F1 of (Expression -> Expression)
    | F2 of (Expression -> Expression -> Expression)
    | F3 of (Expression -> Expression -> Expression -> Expression)
    interface IDerivable

let constant(n : obj) = 
    match n with
    | :? float32 as x -> scalar x  |> Value
    | :? VectorArray<float32> as x -> vector x  |> Value
    | :? MatrixArray<float32> as x -> matrix x  |> Value
    | _ -> failwith "Unknown constant expression."
    
let var(n : string) = name n |> Value

let internal V = Var |> Value

let internal apply<'TReturn> (a:Expression->'TReturn) (expr:Function) = 
    match expr with
        | F1 f -> let f1 = f(var "x1") in a f1
        | F2 f -> 
            let f2 = f(var "x2") in
            let f1 = f2(var "x1") in
            a f1
        | F3 f -> 
            let f3 = f(var "x3") in
            let f2 = f3(var "x2") in
            let f1 = f2(var "x1") in
            a f1
      
//The derivative of f(g(x)) wrt x is f'(g(x)) * g'(x) or df/dg * dg/dx
let rec unary (a:Expression) ff fd df =
    match a with
    | Value x  -> ff x |> Value
    | Expression(x, dx, xtag) -> let cp = fd(x) in Expression(cp, df(cp, x, dx), xtag)
  
 
let rec binary a b ff fd df_da df_db df_dab =
    match a with
    | Value x ->
        match b with
        | Value y ->  ff(x, y) |> Value
        | Expression(y, dy, ytag) -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag)
    
    | Expression(x, dx, xtag) ->
        match b with
        | Value _  -> let cp = fd(x, b) in Expression(cp, df_da(cp, x, dx), xtag)
        | Expression(y, dy, ytag) ->
            match compare xtag ytag with
            | 0 -> let cp = fd(x, y) in Expression(cp, df_dab(cp, x, dx, y, dy), xtag) // ai = bi
            | -1 -> let cp = fd(a, y) in Expression(cp, df_db(cp, y, dy), ytag) // ai < bi
            | _ -> let cp = fd(x, b) in Expression(cp, df_da(cp, y, dy), ytag) // ai > bi
     

let primal d = 
    let p e =
        match e with
        | Value _ -> Expression(e, Expression.Zero, 0u)
        | Expression(x, _, _) -> x
  
    match box d with
    | :? Expression as e -> p e
    | :? (Expression -> Expression) as f1 -> Function.F1 f1 |> apply p 
    | :? (Expression -> Expression -> Expression) as f2 -> Function.F2 f2 |> apply p
    | _ -> failwith "Unknown derivable signature"
    

let derivative d =
    let derive e =
        match e with
        | Value _ -> Expression.Zero
        | Expression(_, df, _) -> df
    match box d with
    | :? Expression as e -> derive e
    | :? (Expression -> Expression) as f1 -> Function.F1 f1 |> apply derive 
    | _ -> failwith "Unknown derivable signature"
  

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
    
let inline diff f x = (primal f, derivative f, GlobalTagger.Next) |> Expression 

