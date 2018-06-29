using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;


namespace Adrien.Trees
{
    public class TreeBuilderContext : IDisposable
    {
        public ExpressionTree Tree { get; }

        public Stack<Expression> Operands { get; }

        public Stack<Op> Operators { get; }

        public Stack<object> O { get; }

        public Stack<TreeNode> TreeNodeStack { get; }

        public Op CurrentOp => Operators.Peek();

        public OperatorNode LastTreeNodeAsOperator => (TreeNodeStack.Peek() as OperatorNode) ?? throw new Exception("The current tree node is not an operator node.");

        public ValueNode LastTreeNodeAsValue => (TreeNodeStack.Peek() as ValueNode) ?? throw new Exception("The current tree node is not a value node.");

        public TreeBuilderContext(ExpressionTree tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<TreeNode>(tree.Children.Cast<TreeNode>());
            this.TreeNodeStack.Push(Tree);
            this.Operands = new Stack<Expression>();
            this.Operators = new Stack<Op>();
            this.O = new Stack<object>();
        }

        public T LastTreeValueNodeAs<T>()
        {
            ValueNode v = (TreeNodeStack.Peek() as ValueNode) ?? throw new Exception("The current tree node is not a value node.");
            if (v.Value is T)
            {
                return (T)v.Value;
            }
            else
            {
                throw new Exception($"The current tree value node is not of type {typeof(T)}.");
            }
        }

        public TreeBuilderContext Operation(Op op)
        {
            Operators.Push(op);
            O.Push(Operators.Peek());
            return this;
        }

        public TreeBuilderContext Operand (Expression operand)
        {
            Operands.Push(operand);
            O.Push(Operands.Peek());
            return this;
        }

        public OperatorNode AddOperatorNode(Op op)
        {
            TreeNodePosition pos = LastTreeNodeAsOperator.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            OperatorNode on = new OperatorNode(LastTreeNodeAsOperator, op, pos);
            this.Tree.AddNode(on);
            this.TreeNodeStack.Push(on);
            return on;
            
        }

        public ValueNode AddValueNode(OperatorNode parent, object value)
        {
            TreeNodePosition pos = parent.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            ValueNode vn = new ValueNode(parent, value, pos);
            this.Tree.AddNode(vn);
            this.TreeNodeStack.Push(vn);
            return vn;    
        }

        public ValueNode AddValueNode(object value) => AddValueNode(LastTreeNodeAsOperator, value);

        public void Dispose()
        {
            if (O.Peek() is Op)
            {
                Operators.Pop();
            }
            if (O.Peek() is Expression)
            {
                Operands.Pop();
            }
            O.Pop();
        }

    }
}
