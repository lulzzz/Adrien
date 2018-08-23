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

        public override List<TensorOp> ContractionOperators { get; } = new List<TensorOp>()
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
                    string lhs = s.Split('=').First().TrimEnd(), rhs = s.Split('=').Last().TrimEnd();
                    AddElementwiseVariableDefinition(lhs, rhs, s);
                    Context.Push(lhs);
                    return;

                case TensorOp.IndexedAssign:
                    if (TreeNodeIsTensor(on.Right) || TreeNodeIsContractionOp(on.Right))
                    {
                        base.VisitInternal(on);
                        s = (string)Context.Pop();
                        lhs = s.Split('=').First().TrimEnd(); rhs = s.Split('=').Last().TrimEnd();
                        AddIndexVariableDefinition(lhs, rhs, s);
                        Context.Push(lhs);
                        return;
                    }
                    else
                    {
                        var rhsOp = (ITreeOperatorNode<TensorOp>)on.Right;
                        if (TreeNodeIsContractionOp(rhsOp.Left) && 
                           (TreeNodeIsElementwiseOp(rhsOp.Right) || TreeNodeIsTensor(rhsOp.Right)))
                        {
                            string leftIndexVarName = on.Left.Left.Label.ToUpper();
                            Visit(on.Left);
                            string leftIndexVar = (string)Context.Pop();
                            string newLeftIndexVarName = GetNewIndexVariableName(leftIndexVarName);
                            string newLeftIndexVar = leftIndexVar.Replace(leftIndexVarName, newLeftIndexVarName);

                            Visit(rhsOp.Left);
                            string contractionOp = (string) Context.Pop();
                            s = string.Format(Writer.GetOperatorTemplate(TensorOp.IndexedAssign), newLeftIndexVar, contractionOp);
                            AddIndexVariableDefinition(newLeftIndexVar, contractionOp, s);

                            Visit(rhsOp.Right);
                            string rightOp = string.Format(Writer.GetOperatorTemplate(rhsOp.Op), newLeftIndexVarName, 
                                (string)Context.Pop());
                            s = string.Format(Writer.GetOperatorTemplate(TensorOp.ElementWiseAssign), leftIndexVarName, rightOp); 
                            AddElementwiseVariableDefinition(leftIndexVarName, rightOp, s);

                            Context.Push(Writer.WriteOperator(TensorOp.ElementWiseAssign, leftIndexVarName, rightOp));
                        }
                        return;
                        
                    }

                default:
                    base.VisitInternal(on);
                    return;
            }
        }

        protected bool TreeNodeIsTensor(ITreeNode node) =>
            node is ITreeValueNode vn && vn.NodeType == ValueNodeType.TENSOR;

        protected bool TreeNodeIsIndexOp(ITreeNode node) =>
         node is ITreeOperatorNode<TensorOp> on && on.Op == TensorOp.Index;

        protected bool TreeNodeIsContractionOp(ITreeNode node) =>
          node is ITreeOperatorNode<TensorOp> on && ContractionOperators.Contains(on.Op);

        protected bool TreeNodeIsElementwiseOp(ITreeNode node) =>
          node is ITreeOperatorNode<TensorOp> on && !ContractionOperators.Contains(on.Op);

        protected bool TreeOperatorNodeLHSIsTensor(ITreeOperatorNode<TensorOp> on)
        {
            if (on.Left is ITreeValueNode vn)
            {
                return vn.NodeType == ValueNodeType.TENSOR;
            }
            else if ((on.Left is ITreeOperatorNode<TensorOp> op) 
                 && (op.Op == TensorOp.ElementWiseAssign || op.Op == TensorOp.IndexedAssign))
            {
                return TreeOperatorNodeLHSIsTensor(op);
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

