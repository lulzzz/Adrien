using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public abstract class TreeVisitor<TOp, TContextInternal, TContextLeaf> : ITreeVisitor<TOp>
    {
        public IExpressionTree Tree { get; set; }

        public TreeVisitorContext<TOp, TContextInternal, TContextLeaf> Context { get; protected set; }

        public TreeVisitor(IExpressionTree tree, bool visit = true) : base()
        {
            Tree = tree;
            if (visit)
            {
                Visit(tree);
                AfterVisit();
            }
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
            if (on.Left != null)
            {
                Visit(on.Left);
            }
            if (on.Right != null)
            {
                Visit(on.Right);
            }            
        }

        public abstract void AfterVisit();
        
    }
}
