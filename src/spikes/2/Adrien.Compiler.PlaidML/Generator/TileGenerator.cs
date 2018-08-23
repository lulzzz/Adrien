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

        public override List<TensorOp> IndexOperators { get; } = new List<TensorOp>()
        {
            TensorOp.Sum
        };


        public List<ITermShape> InputShapes => Tree.InputVariableNodes.Select(t => t.ValueAs<ITermShape>()).ToList();
            
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
            WriteFunctionPrologue();
        }

        public override void VisitInternal(ITreeOperatorNode<TensorOp> on)
        {
            switch(on.Op)
            {
                case TensorOp.ElementWiseAssign:
                    base.VisitInternal(on);
                    string s = (string)Context.Pop();
                    Writer.VariableDefinitions.Enqueue(s);
                    string lhs = s.Split('=').First().TrimEnd();
                    Context.Push(lhs);
                    return;

                case TensorOp.IndexAssign:
                    if (on.Right is ITreeValueNode || TreeNodeIsIndexOp(on.Right))
                    {
                        base.VisitInternal(on);
                        return;
                    }
                    else
                    {
                        var rhsOp = (ITreeOperatorNode<TensorOp>)on.Right;
                        var l = rhsOp.Left;
                        var r = rhsOp.Right;
                        if (TreeNodeIsIndexOp(l) && TreeNodeIsElementwiseOp(r))
                        {
                            base.Visit(on.Left);
                            string indexVar = (string)Context.Pop();
                            string newIndexVarName = GetValidNewIndexVariableName(on.Left.Label);
                            indexVar = indexVar.Replace(on.Left.Label, newIndexVarName);
                            base.Visit(l);
                            string indexOp = (string) Context.Pop();
                            s = indexVar  + " = " + indexOp;
                            Writer.VariableDefinitions.Enqueue(s);
                            base.Visit(r);
                            string rr = (string)Context.Pop();
                            Context.Push(Writer.WriteOperator(on.Op, indexOp, rr));
                        }
                        return;
                        
                    }

                default:
                    base.VisitInternal(on);
                    return;
            }
        }

        protected bool TreeNodeIsIndexAssign(ITreeNode node) =>
            node is ITreeOperatorNode<TensorOp> on && on.Op == TensorOp.IndexAssign;

        protected bool TreeNodeIsElementwiseAssign(ITreeNode node) =>
            node is ITreeOperatorNode<TensorOp> on && on.Op == TensorOp.ElementWiseAssign;

        protected bool TreeNodeIsIndexOp(ITreeNode node) =>
          node is ITreeOperatorNode<TensorOp> on && IndexOperators.Contains(on.Op);

        protected bool TreeNodeIsElementwiseOp(ITreeNode node) =>
          node is ITreeOperatorNode<TensorOp> on && !IndexOperators.Contains(on.Op);

        protected bool LHSIsTensor(ITreeOperatorNode<TensorOp> on)
        {
            if (on.Left is ITreeValueNode vn)
            {
                return vn.NodeType == ValueNodeType.TENSOR;
            }
            else if ((on.Left is ITreeOperatorNode<TensorOp> op) && (op.Op == TensorOp.ElementWiseAssign))
            {
                return LHSIsTensor(op);
            }
            else
            {
                return false;
            }
        }

        protected string WriteInputVariableDimensions(ITermShape input)
        {
            StringBuilder dimensions = new StringBuilder("[");
            dimensions.Append(Enumerable.Range(0, input.Rank)
                .Select(d => input.Label + d.ToString())
                .Aggregate((d1, d2) => d1 + "," + d2));
            dimensions.Append("]");
            return dimensions.ToString();
        }


        protected void WriteFunctionPrologue()
        {
            StringBuilder prologue = new StringBuilder("function(");
            foreach(ITermShape tensor in InputShapes)
            {
                prologue.AppendFormat("{0}{1}, ", tensor.Label.ToUpper(), WriteInputVariableDimensions(tensor).ToUpper());   
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

