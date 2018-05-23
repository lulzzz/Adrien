module Adrien.Tree

open Adrien.Numeric
open Adrien.Expression
open Adrien

type TreeNode = 
    | ValueNode of ValueNode
    | OperatorNode of OperatorNode

and ValueNode = {
    Id: int
    Shape : Shape
    Format : Format
    Parent : int
    Data: obj
}

and OperatorNode = {
    Id: int
    Op : Op 
    Left: TreeNode
    Right: TreeNode option
    Parent: int
}

type Tree = 
    | Singleton of ValueNode
    | Tree of parent:OperatorNode 

type TreeNodePosition =
    | Left
    | Right

let with_id (new_id: int) (node:TreeNode) :TreeNode =
    match node with
    | ValueNode l -> {Id = new_id; Shape = l.Shape; Format = l.Format; Parent = l.Parent; Data = l.Data} |> ValueNode
    | OperatorNode n -> {Id = new_id; Op = n.Op; Parent = n.Parent; Left = n.Left; Right = n.Right } |> OperatorNode

let with_parent (parent: int) (node:TreeNode) :TreeNode=
    match node with
    | ValueNode l -> {Id = l.Id; Shape = l.Shape; Format = l.Format; Parent = parent; Data = l.Data} |> ValueNode
    | OperatorNode n -> {Id = n.Id; Op = n.Op; Parent = parent; Left = n.Left; Right = n.Right } |> OperatorNode

let count_children (node:TreeNode) =
    let rec count start (node:TreeNode) = 
        match node with
        | ValueNode l -> start
        | OperatorNode i -> 
            let lcount = count (start + 1) i.Left
            let rcount = if i.Right.IsSome then count (lcount + 1) i.Right.Value else lcount
            rcount
    count 0 node

let node_id node =
    match node with
    | ValueNode v -> v.Id
    | OperatorNode o -> o.Id

let rec node (parent: int) (expr: Expression) :TreeNode =
    let nid = parent + 1
    match expr with
    | Constant e -> 
        match e.Op with
        | Some op -> //Non-leaf node
            match op with
            | Unary -> 
                {Id = nid; Op = op; Parent = parent; Left = e.Left |> Option.get |> Constant |> node nid; Right = None} |> OperatorNode 
            | Binary -> 
                let lnode = e.Left |> Option.get |> Constant |> node nid
                let rid = node_id lnode + 1
                let rnode = e.Right |> Option.get |> Constant |> node (nid) |> with_id (rid + count_children(lnode) )|> Some
                {Id = nid; Op = op; Parent = parent; Left = lnode; Right = rnode} |> OperatorNode
        | None -> {Id = nid; Shape = e.Shape; Format = e.Format; Parent = parent; Data = e.Data } |> TreeNode.ValueNode//leaf node
    
    | Expression(x, _, _) -> node parent x

    | Function f -> let v = f(V) in node parent v

    | CFunction gf -> let v2 = gf(V) in node parent (v2 |> Expression.Function)
  
let internal node_tree (node:TreeNode) :Tree = 
    match node with
    | ValueNode l -> l |> Tree.Singleton
    | OperatorNode n -> Tree(n)

let rec expr_tree (expr:Expression) = 
    match expr with
    | Constant c -> c |> Expression.Constant |> node 0 |> node_tree
    | Expression (x, dx, xtag) -> (x, dx, xtag) |> Expression.Expression |> node 0 |> node_tree
    | Function f -> let v = f(V) in expr_tree v
    | CFunction gf -> let v2 = gf(V) in expr_tree (v2 |> Expression.Function)

let compose(gf:Expression -> Expression -> Expression) :Expression -> Expression =
    let v2 = gf(V)
    v2

let composite(gf:Expression -> Expression -> Expression) :Expression -> Expression = compose gf
let tree (f:Expression -> Expression) = f |> Expression.Function |> expr_tree
let ctree (f:Expression -> Expression -> Expression) = f |> Expression.CFunction |> expr_tree
