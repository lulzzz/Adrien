using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Adrien.Trees
{
    public abstract class TreeVisitorContext<TOp, TInternal, TLeaf> : ITreeVisitorContext<TOp, TInternal, TLeaf>
    {
        public IExpressionTree Tree { get; protected set; }

        public Stack<TLeaf> LeafNodes { get; protected set; }

        public Stack<TInternal> InternalNodes { get; protected set; }

        public Stack<object> O { get; protected set; }

        public Stack<ITreeNode> TreeNodeStack { get; protected set; }

        public bool IsInternal => InternalNodes.Count > 0;

        public TInternal InternalNode => InternalNodes.Peek();

        public ITreeOperatorNode<TOp> LastTreeNodeAsOperator => (TreeNodeStack.Peek() as ITreeOperatorNode<TOp>) ?? throw new Exception("The current tree node is not an operator node.");

        public ITreeValueNode LastTreeNodeAsValueNode => (TreeNodeStack.Peek() as ITreeValueNode) ?? throw new Exception("The current tree node is not a value node.");


        public TreeVisitorContext(IExpressionTree tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>(tree.Children);
            this.TreeNodeStack.Push(Tree);
            this.LeafNodes = new Stack<TLeaf>();
            this.InternalNodes = new Stack<TInternal>();
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

        public ITreeVisitorContext<TOp, TInternal, TLeaf> Internal(TInternal ctx)
        {
            InternalNodes.Push(ctx);
            O.Push(InternalNodes.Peek());
            return this;
        }
        
        public ITreeVisitorContext<TOp, TInternal, TLeaf> Leaf (TLeaf ctx)
        {
            LeafNodes.Push(ctx);
            O.Push(LeafNodes.Peek());
            return this;
        }

        
        public void Dispose()
        {
        
            if (O.Peek() is TInternal)
            {
                InternalNodes.Pop();
            }
            else if (O.Peek() is TLeaf)
            {
                LeafNodes.Pop();
            }
            O.Pop();
        }

    }
}
