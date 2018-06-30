using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;


namespace Adrien.Trees
{
    public class TreeBuilderContext : TreeVisitorContext<Op, Op, Expression>
    {
        public TreeBuilderContext(IExpressionTree tree) : base(tree) {}


        public OperatorNode AddOperatorNode(Op op)
        {
            TreeNodePosition pos = LastTreeNodeAsOperator.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            OperatorNode on = new OperatorNode(LastTreeNodeAsOperator, op, pos);
            this.Tree.AddNode(on);
            this.TreeNodeStack.Push(on);
            return on;
        }

        public ValueNode AddValueNode(ITreeOperatorNode<Op> parent, object value)
        {
            TreeNodePosition pos = parent.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            ValueNode vn = new ValueNode(parent, value, pos);
            if (pos == TreeNodePosition.LEFT)
            {
                parent.Left = vn;
            }
            else
            {
                parent.Right = vn;
            }
            this.Tree.AddNode(vn);
            this.TreeNodeStack.Push(vn);
            return vn;    
        }

        public ValueNode AddValueNode(object value) => AddValueNode(LastTreeNodeAsOperator, value);
    }
}
