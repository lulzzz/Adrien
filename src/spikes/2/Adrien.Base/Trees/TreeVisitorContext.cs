using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Adrien.Trees
{
    public abstract class TreeVisitorContext<TOp, TTreeNode> : ITreeVisitorContext<TOp, TTreeNode>
    {
        public IExpressionTree Tree { get; protected set; }

        public Stack<TTreeNode> Operands { get; protected set; }

        public Stack<TOp> Operators { get; protected set; }

        public Stack<object> O { get; protected set; }

        public Stack<ITreeNode> TreeNodeStack { get; protected set; }

        public TOp CurrentOp => Operators.Peek();

        public ITreeOperatorNode<TOp> LastTreeNodeAsOperator => (TreeNodeStack.Peek() as ITreeOperatorNode<TOp>) ?? throw new Exception("The current tree node is not an operator node.");

        public ITreeValueNode LastTreeNodeAsValueNode => (TreeNodeStack.Peek() as ITreeValueNode) ?? throw new Exception("The current tree node is not a value node.");


        public TreeVisitorContext(IExpressionTree tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>(tree.Children);
            this.TreeNodeStack.Push(Tree);
            this.Operands = new Stack<TTreeNode>();
            this.Operators = new Stack<TOp>();
            this.O = new Stack<object>();
        }
        

        public T LastTreeValueNodeAs<T>()
        {
            if (LastTreeNodeAsValueNode.Value is T)
            {
                return (T) LastTreeNodeAsValueNode.Value;
            }
            else
            {
                throw new Exception($"The current tree value node is not of type {typeof(T)}.");
            }
        }

        public ITreeVisitorContext<TOp, TTreeNode> Operation(TOp op)
        {
            Operators.Push(op);
            O.Push(Operators.Peek());
            return this;
        }

        public ITreeVisitorContext<TOp, TTreeNode> Operand (TTreeNode operand)
        {
            Operands.Push(operand);
            O.Push(Operands.Peek());
            return this;
        }

        
        public void Dispose()
        {
            if (O.Peek() is TOp)
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
