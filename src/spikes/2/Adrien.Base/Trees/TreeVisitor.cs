using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public abstract class TreeVisitor<TOp> : ITreeVisitor<TOp>
    {
        public IExpressionTree Tree { get; set; }

        internal TreeVisitorContext<TOp, ITreeNode> Context { get; set; }

        public TreeVisitor(IExpressionTree tree, bool visit = true) : base()
        {
          
            Tree = tree;
        }


        public void Visit(ITreeNode tn)
        {
            if (tn is ITreeOperatorNode<TOp>)
            {
                VisitInternal(tn as ITreeOperatorNode<TOp>);
            }
            else
            {
                VisitLeaf(tn as ITreeValueNode);
            }

        }

        public abstract void VisitLeaf(ITreeValueNode node);
        
        public virtual void VisitInternal(ITreeOperatorNode<TOp> on)
        {
            using (var op = Context.Operation(on.Op))
            {
                if (on.Left != null)
                {
                    Visit(on.Left);
                }
                if (on.Right != null)
                {
                    Visit(on.Right);
                }
            }
        }
    }
}
