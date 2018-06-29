using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;



namespace Adrien.Trees
{
    public abstract class TreeVisitorContext<TTreeNode> : ITreeVisitorContext<Op, TTreeNode>
    {
        public IExpressionTree Tree { get; }

        public Stack<TTreeNode> Operands { get; }

        public Stack<Op> Operators { get; }

        public Stack<object> O { get; }

        public Stack<ITreeNode> TreeNodeStack { get; }

        public Op CurrentOp => Operators.Peek();

        public ITreeOperatorNode<Op> LastTreeNodeAsOperator => (TreeNodeStack.Peek() as OperatorNode) ?? throw new Exception("The current tree node is not an operator node.");

        public ITreeValueNode LastTreeNodeAsValue => (TreeNodeStack.Peek() as ITreeValueNode) ?? throw new Exception("The current tree node is not a value node.");


        public TreeVisitorContext(IExpressionTree tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>(tree.Children.Cast<TreeNode>());
            this.TreeNodeStack.Push(Tree);
            this.Operands = new Stack<TTreeNode>();
            this.Operators = new Stack<Op>();
            this.O = new Stack<object>();
        }


        public abstract void OpNodeAction(Op op);

        public abstract void ValueAction(ValueNode node);

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

        public ITreeVisitorContext<Op, TTreeNode> Operation(Op op)
        {
            Operators.Push(op);
            O.Push(Operators.Peek());
            return this;
        }

        public ITreeVisitorContext<Op, TTreeNode> Operand (TTreeNode operand)
        {
            Operands.Push(operand);
            O.Push(Operands.Peek());
            return this;
        }

        
        public void Dispose()
        {
            if (O.Peek() is Op)
            {
                Operators.Pop();
            }
            if (O.Peek() is TTreeNode)
            {
                Operands.Pop();
            }
            O.Pop();
        }

    }
}
