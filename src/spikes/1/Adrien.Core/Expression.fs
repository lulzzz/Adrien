module Adrien.Expression

open Adrien.Numeric
open Adrien.Tagger

type IDerivable = interface end

type Expression =
    | Expression of Numeric
    | Dual of e: Expression * de: Expression * tag: uint32  
    interface IDerivable
 
    static member Zero = scalar 0.0f |> Expression

type Function =
    | F1 of (Expression -> Expression)
    | F2 of (Expression -> Expression -> Expression)
    | F3 of (Expression -> Expression -> Expression -> Expression)
    interface IDerivable

let constant(n : obj) = 
    match n with
    | :? float32 as x -> scalar x  |> Expression
    | :? VectorArray<float32> as x -> vector x  |> Expression
    | :? MatrixArray<float32> as x -> matrix x  |> Expression
    | _ -> failwith "Unknown constant expression."
    
let var(n : string) = name n |> Expression

let internal V = Var |> Expression

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
      

let rec unary (a:Expression) ff fd df =
    match a with
    | Expression x  -> ff x |> Expression
    | Dual(x, xdual, xtag) -> let cp = fd(x) in Dual(cp, df(cp, x, xdual), xtag)
  
 
let rec binary a b ff fd df_da df_db df_dab =
    match a with
    | Expression x ->
        match b with
        | Expression y ->  ff(x, y) |> Expression
        | Dual(y, ydual, ytag) -> let cp = fd(a, y) in Dual(cp, df_db(cp, y, ydual), ytag)
    
    | Dual(x, xdual, xtag) ->
        match b with
        | Expression _  -> let cp = fd(x, b) in Dual(cp, df_da(cp, x, xdual), xtag)
        | Dual(y, ydual, ytag) ->
            match compare xtag ytag with
            | 0 -> let cp = fd(x, y) in Dual(cp, df_dab(cp, x, xdual, y, ydual), xtag) // ai = bi
            | -1 -> let cp = fd(a, y) in Dual(cp, df_db(cp, y, ydual), ytag) // ai < bi
            | _ -> let cp = fd(x, b) in Dual(cp, df_da(cp, y, ydual), ytag) // ai > bi
     

let primal d = 
    let p e =
        match e with
        | Expression _ -> e
        | Dual(x, _, _) -> x
  
    match box d with
    | :? Expression as e -> p e
    | :? (Expression -> Expression) as f1 -> Function.F1 f1 |> apply p 
    | :? (Expression -> Expression -> Expression) as f2 -> Function.F2 f2 |> apply p
    | _ -> failwith "Unknown derivable signature"
    

let derivative d =
    let derive e =
        match e with
        | Expression _ -> Expression.Zero
        | Dual(_, df, _) -> df
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
    
//let inline diff f x = (primal f, derivative f, GlobalTagger.Next) |> Expression 

