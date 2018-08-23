using System;
using System.Collections.Generic;
using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGenerator<TOp, TWriter> : TreeVisitor<TOp, string, string>
        where TWriter : LanguageWriter<TOp>
    {
        public abstract List<TOp> NestedBinaryOperators { get; }

        public abstract List<TOp> IndexOperators { get; }

        public Dictionary<string, string> ElementwiseVariableDefinitions { get; } = new Dictionary<string, string>();

        public Dictionary<string, string> IndexVariableDefinitions { get; } = new Dictionary<string, string>();

        public string Text => Context.InternalNode;

        public bool Success { get; protected set; }

        protected TWriter Writer { get; set; }


        public LanguageGenerator(IExpressionTree tree) : base(tree, false) {}

       
        public override void VisitInternal(ITreeOperatorNode<TOp> on)
        {
            var operands = new Stack<string>();
            using (Context.Internal(Writer.GetOperatorTemplate(on)))
            {
                base.VisitInternal(on);

                if (on.Right != null)
                {
                    if (on.Right is ITreeOperatorNode<TOp> 
                        && NestedBinaryOperators.Contains(on.Op)
                        && NestedBinaryOperators.Contains((on.Right as ITreeOperatorNode<TOp>).Op))
                    {
                        operands.Push("(" + (string) Context.Pop() + ")");
                    }
                    else
                    {
                        operands.Push((string) Context.Pop());
                    }
                }

                if (on.Left != null)
                {
                    if (on.Left is ITreeOperatorNode<TOp> 
                        && NestedBinaryOperators.Contains(on.Op)
                        && NestedBinaryOperators.Contains((on.Left as ITreeOperatorNode<TOp>).Op))
                    {
                        operands.Push("(" + (string) Context.Pop() + ")");
                    }
                    else
                    {
                        operands.Push((string) Context.Pop());
                    }
                }
            }

            Context.Push(Writer.WriteOperator(on.Op, operands.ToArray()));
        }

        public override void VisitLeaf(ITreeValueNode node)
        {
            Context.Push(Writer.WriteValueText(node));
        }

        public override void AfterVisitTree()
        {
            if (Context.Count != 1)
            {
                throw new LanguageGeneratorException<TOp, TWriter>(this, $"Context has {Context.Count} nodes, not 1.");
            }

            Success = true;
        }

        public bool ContextIsOpStart(TOp op)
        {
            return (string) Context.Peek() == Writer.GetOperatorTemplate(op);
        }

        protected string GetValidNewIndexVariableName(string name, int n = 0)
        {
            if (!IndexVariableDefinitions.ContainsKey(name + n.ToString()))
            {
                return GetValidNewIndexVariableName(name, n + 1);
            }
            else
            {
                return name + n.ToString();
            }
        }

    }
}