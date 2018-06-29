using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;


namespace Adrien.Trees
{
    public class TreeBuilderContext : TreeVisitorContext<Op, Expression>
    {
       
        public TreeBuilderContext(IExpressionTree tree) : base(tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>(tree.Children.Cast<TreeNode>());
            this.TreeNodeStack.Push(Tree);
            this.Operands = new Stack<Expression>();
            this.Operators = new Stack<Op>();
            this.O = new Stack<object>();
        }

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
            this.Tree.AddNode(vn);
            this.TreeNodeStack.Push(vn);
            return vn;    
        }

        public ValueNode AddValueNode(object value) => AddValueNode(LastTreeNodeAsOperator, value);

        

    }
}
