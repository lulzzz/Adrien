using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class TreeVisitor : ITreeVisitor<Op>
    {
        public ExpressionTree Tree { get; set; }

        internal TreeVisitorContext<TreeNode> Context { get; set; }

        public TreeVisitor(ExpressionTree tree, bool visit = true) : base()
        {
          
            Tree = tree;
        }

        public void Visit(ITreeNode tn)
        {
            if (tn is ITreeOperatorNode<Op>)
            {
                VisitInternal(tn as ITreeOperatorNode<Op>);
            }
            else
            {
                VisitLeaf(tn as ITreeValueNode);
            }

        }

        public void VisitLeaf(ITreeValueNode node)
        {

        }

        public void VisitInternal(ITreeOperatorNode<Op> on)
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
