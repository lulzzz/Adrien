module Adrien.Tree


open Adrien.Numeric
open Adrien.Expression
open Adrien.LinqExpression

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
    Parent: int
    Id: int
    Op : Op 
    Left: TreeNode
    Right: TreeNode option
    
}

type Tree = 
    | Singleton of ValueNode
    | Tree of parent:OperatorNode 

type TreeNodePosition =
    | Left
    | Right

let withId (newId: int) (node:TreeNode) :TreeNode =
    match node with
    | ValueNode l -> {Id = newId; Shape = l.Shape; Format = l.Format; Parent = l.Parent; Data = l.Data} |> ValueNode
    | OperatorNode n -> {Id = newId; Op = n.Op; Parent = n.Parent; Left = n.Left; Right = n.Right } |> OperatorNode

let withParent (parent: int) (node:TreeNode) :TreeNode=
    match node with
    | ValueNode l -> {Id = l.Id; Shape = l.Shape; Format = l.Format; Parent = parent; Data = l.Data} |> ValueNode
    | OperatorNode n -> {Id = n.Id; Op = n.Op; Parent = parent; Left = n.Left; Right = n.Right } |> OperatorNode

let countChildren (node:TreeNode) =
    let rec count start (node:TreeNode) = 
        match node with
        | ValueNode l -> start
        | OperatorNode i -> 
            let lcount = count (start + 1) i.Left
            let rcount = if i.Right.IsSome then count (lcount + 1) i.Right.Value else lcount
            rcount
    count 0 node

let nodeId node =
    match node with
    | ValueNode v -> v.Id
    | OperatorNode o -> o.Id

let rec node (parent: int) (expr: Expression) :TreeNode =
    let nid = parent + 1
    match expr with
    | Value e -> 
        match e.Op with
        | Some op -> //Non-leaf node
            match op with
            | Unary -> 
                {Id = nid; Op = op; Parent = parent; Left = e.Left |> Option.get |> Value |> node nid; Right = None} |> OperatorNode 
            | Binary -> 
                let lnode = e.Left |> Option.get |> Value |> node nid
                let rid = nodeId lnode + 1
                let rnode = e.Right |> Option.get |> Value |> node (nid) |> withId (rid + countChildren(lnode) )|> Some
                {Id = nid; Op = op; Parent = parent; Left = lnode; Right = rnode} |> OperatorNode
        | None -> {Id = nid; Shape = e.Shape; Format = e.Format; Parent = parent; Data = e.Data } |> TreeNode.ValueNode//leaf node
    
    | Expression(x, _, _) -> node parent x
  
let internal nodeTree (node:TreeNode) :Tree = 
    match node with
    | ValueNode l -> l |> Tree.Singleton
    | OperatorNode n -> Tree(n)

let rec exprTree (expr:Expression) = 
    match expr with
    | Value c -> c |> Expression.Value |> node 0 |> nodeTree
    | Expression (x, dx, xtag) -> (x, dx, xtag) |> Expression.Expression |> node 0 |> nodeTree
   

let tree d = 
    match box d with
    | :? Expression as e -> exprTree e
    | :? (Expression -> Expression) as f1 -> Function.F1 f1 |> apply exprTree
    | _ -> failwith "Unknown function signature"


let linqExprToTree (expr: LinqExpression) =
    let rec buildTreeNode (parent:int) (expr:LinqExpression) =
        let lid = parent + 1
        let rid = parent + 2
        match expr with
        | ConstantExpression c -> 
            match c with
                | Float32Expression -> {Shape = Scalar; Format = Float32; Parent = parent; Id = lid; Data = c.Value } |> ValueNode
        
        | BinaryExpression be -> 
            match be with 
            | AddExpression ->  {Parent = parent; Id = lid; Op = Add; 
                                Left = buildTreeNode lid be.Left; Right = be.Right |> buildTreeNode lid |> withId rid |> Some} |> OperatorNode
            | SubtractExpression ->  {Parent = parent; Id = lid; Op = Sub; 
                                Left = buildTreeNode lid be.Left; Right = be.Right |> buildTreeNode lid |> withId rid |> Some} |> OperatorNode
            | MultiplyExpression ->  {Parent = parent; Id = lid; Op = Mul; 
                                Left = buildTreeNode lid be.Left; Right = be.Right |> buildTreeNode lid |> withId rid |> Some} |> OperatorNode
            | DivideExpression ->  {Parent = parent; Id = lid; Op = Div; 
                                Left = buildTreeNode lid be.Left; Right = be.Right |> buildTreeNode lid |> withId rid |> Some} |> OperatorNode
            | _ -> failwith "Unknown binary expression."
        | _ -> failwith "Unknown Linq expression."
    buildTreeNode 0 expr
                
