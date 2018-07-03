using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGenerator<TOp, TWriter> : TreeVisitor<TOp, string, string> where TWriter : LanguageWriter<TOp>
    {
        protected TWriter Writer { get; set; }


        public LanguageGenerator(IExpressionTree tree) : base(tree, false) {}


        public override void VisitInternal(ITreeOperatorNode<TOp> on)
        {
            Stack<string> operands = new Stack<string>();
            using (Context.Internal(Writer.GetOperatorText(on)))
            {
                base.VisitInternal(on);

                if (on.Right != null)
                {
                    operands.Push((string)Context.Pop());
                }
                if (on.Left != null)
                {
                    operands.Push((string)Context.Pop());
                }
            }
            Context.Push(Writer.WriteOperator(on.Op, operands.ToArray()));
        }

        public override void VisitLeaf(ITreeValueNode node)
        {
            Context.Push(Writer.WriteValueText(node));
        }
    }
}
