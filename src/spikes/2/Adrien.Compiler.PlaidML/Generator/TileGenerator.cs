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
        public override List<TensorOp> BinaryOperators { get; } = new List<TensorOp>()
        {
            TensorOp.Mul, TensorOp.Add, TensorOp.Sub, TensorOp.Div
        };

        public List<ITreeValueNode> InputTensors =>
           Tree.TensorNodes
           .Distinct(Tree)
           .Where(t => t.Label != Tree.OutputNode.Label)
           .Where(t => !Tree.VariableNodes.Contains(t))
           .ToList();

        public List<IVariableShape> InputShapes => 
            Tree.TensorNodes
            .Distinct(Tree)
            .Where(t => t.Label != Tree.OutputNode.Label)
            .Where(t => !Tree.VariableNodes.Contains(t))
            .Select(t => t.ValueAs<IVariableShape>()).ToList();
            
        public Dictionary<ITreeValueNode, string> TensorDimensionVariables { get; protected set; }

        public string FunctionText { get; protected set; }

        public TileGenerator(IExpressionTree tree) : base(tree)
        {
            Context = new TileGeneratorContext(tree);
            Writer = new TileWriter();
            this.VisitTree();
        }

        
        public override void AfterVisitTree()
        {
            base.AfterVisitTree();
            GetDimenSionVariableNames();
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
                    
                        if (on.Right != null)
                        {
                            base.Visit(on.Right);
                            rhs = (string)Context.Pop();
                        }
                        if (on.Left != null)
                        {
                            base.Visit(on.Left);
                            lhs = (string)Context.Pop();
                        }
                    }
                    Writer.VariableDefinitions.Enqueue(string.Format("{0} = {1};", lhs, rhs) + Environment.NewLine);
                    Context.Push(Writer.WriteOperator(on.Op, lhs));
                    return;
                default:
                    base.VisitInternal(on);
                    return;
            }
        }

        protected void GetDimenSionVariableNames()
        {
            TensorDimensionVariables = new Dictionary<ITreeValueNode, string>(InputTensors.Count);
            foreach(ITreeValueNode v in InputTensors)
            {
                string name = v.Label + "N";
                int n = 0;
                while (TensorDimensionVariables.Values.Contains(name))
                {
                    name = name + (++n).ToString();
                }
                TensorDimensionVariables.Add(v, name);
            }
        }

        protected void RenoveLHSEmptyVariableDeclaration()
        {
            ITreeOperatorNode<TensorOp> root = (ITreeOperatorNode<TensorOp>)Tree.Root;
            if (root.Left is ITreeValueNode)
            {
                ITreeValueNode l = (ITreeValueNode)root.Left;
                if (l.Value == null)
                {
                    string text = Text.Remove(0, "[] = ".Length);
                    this.Context.Push(text);
                }
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

