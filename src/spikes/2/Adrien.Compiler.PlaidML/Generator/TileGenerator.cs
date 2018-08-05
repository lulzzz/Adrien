using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adrien.Generator;
using Adrien.Trees;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileGenerator : LanguageGenerator<TensorOp, TileWriter>
    {
        public override List<TensorOp> NestedBinaryOperators { get; } = new List<TensorOp>()
        {
            TensorOp.Mul, TensorOp.Add, TensorOp.Sub, TensorOp.Div, TensorOp.Square
        };

        public List<ITreeValueNode> Tensors =>
            Tree.TensorNodes
            .Distinct(Tree)
            .ToList();

        public List<ITreeValueNode> InputTensors =>
           Tree.TensorNodes
           .Distinct(Tree)
           .Where(t => t.Label != Tree.OutputNode.Label)
           .Where(t => !Tree.VariableNodes.Contains(t))
           .ToList();

        public List<ITermShape> InputShapes => InputTensors.Select(t => t.ValueAs<ITermShape>()).ToList();
            
        public Dictionary<ITreeValueNode, string> TensorDimensionVariables { get; protected set; }

        public string FunctionText { get; protected set; }

        public TileGenerator(IExpressionTree tree) : base(tree)
        {
            Context = new TileGeneratorContext(tree);
            Writer = new TileWriter();
            GetDimensionVariableNames();
            this.VisitTree();
        }

        
        public override void AfterVisitTree()
        {
            base.AfterVisitTree();
            WriteFunctionPrologue();
        }

        public override void VisitInternal(ITreeOperatorNode<TensorOp> on)
        {
            switch(on.Op)
            {
                case TensorOp.ElementWiseAssign:
                    string lhs = "", rhs = "";
                    using (Context.Internal(Writer.GetOperatorTemplate(on)))
                    {                        
                        base.Visit(on.Right);
                        rhs = (string)Context.Pop();
                           
                        base.Visit(on.Left);
                        lhs = (string)Context.Pop();
                        
                    }
                    Writer.VariableDefinitions.Enqueue(string.Format("{0}[] = {1};", lhs, rhs) + Environment.NewLine);
                    Context.Push(Writer.WriteOperator(on.Op, lhs));
                    return;

                case TensorOp.Index:
                    if (Context.Count > 1 || !ContextIsOpStart(TensorOp.Assign))
                    {
                        base.VisitInternal(on);
                        return;
                    }

                    using (Context.Internal(Writer.GetOperatorTemplate(on)))
                    {
                        base.Visit(on.Right);
                        rhs = (string)Context.Pop();
                        base.Visit(on.Left);
                        lhs = (string)Context.Pop();
                    }

                    ITreeValueNode tensor;
                    if (on.Left is ITreeValueNode)
                    {
                        tensor = on.Left as ITreeValueNode;
                        if (tensor.NodeType != ValueNodeType.TENSOR)
                        {
                            throw new Exception("The LHS of the Index operation is not a tensor.");
                        }
                    }
                    else if (on.Left is ITreeOperatorNode<TensorOp> && 
                        (on.Left as ITreeOperatorNode<TensorOp>).Op == TensorOp.ElementWiseAssign)
                    {
                        tensor = (on.Left as ITreeOperatorNode<TensorOp>).Left as ITreeValueNode;
                        if (tensor.NodeType != ValueNodeType.TENSOR)
                        {
                            throw new Exception("The LHS of the Index operation is not a tensoe.");
                        }
                    }
                    else
                    {
                        throw new Exception("Could not determine the LHS side of the Index operation");
                    }
                    var dim = TensorDimensionVariables[tensor];
                    Context.Push(Writer.WriteOperator(on.Op, lhs, rhs + ":" + dim));
                    return;

                default:
                    base.VisitInternal(on);
                    return;
            }
        }

        protected void GetDimensionVariableNames()
        {
            TensorDimensionVariables = new Dictionary<ITreeValueNode, string>(InputTensors.Count);
            foreach(ITreeValueNode v in Tensors)
            {
                string name = v.Label + "N";
                int n = 0;
                while (TensorDimensionVariables.Values.Contains(name))
                {
                    name = name + (++n).ToString();
                }
                TensorDimensionVariables.Add(v, name.ToUpper());
            }
        }

        protected void WriteFunctionPrologue()
        {
            StringBuilder prologue = new StringBuilder("function(");
            foreach(ITreeValueNode tensor in InputTensors)
            {
                if (!Tree.IndexSetNodes.Any(set => set.Parent.Label == tensor.Label))
                {
                    prologue.AppendFormat("{0}, ", tensor.Label.ToUpper());
                }
            }
            prologue.Remove(prologue.Length - 2, 2);
            prologue.Append(") -> ");
            if (!Tree.IndexSetNodes.Any(set => set.Parent.Label == Tree.OutputNode.Label))
            {
                prologue.AppendFormat("({0})", Tree.OutputNode.Label.ToUpper());
            }
            prologue.Append(" { ");
            FunctionText = prologue + this.Text + "}";
        }
    }
}

