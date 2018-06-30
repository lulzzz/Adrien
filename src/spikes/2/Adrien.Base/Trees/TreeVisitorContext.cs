using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Adrien.Trees
{
    public abstract class TreeVisitorContext<TOp, TInternal, TLeaf> : ITreeVisitorContext<TOp, TInternal, TLeaf>
    {
        public IExpressionTree Tree { get; protected set; }

        public Stack<TLeaf> ContextLeafNodes { get; protected set; }

        public Stack<TInternal> ContextInternalNodes { get; protected set; }

        public Stack<object> ContextNodes { get; protected set; }

        public Stack<ITreeNode> TreeNodeStack { get; protected set; }

        public bool IsInternal => ContextInternalNodes.Count > 0;

        public TInternal InternalNode => ContextInternalNodes.Peek();

        public ITreeOperatorNode<TOp> LastTreeNodeAsOperator => (TreeNodeStack.Peek() as ITreeOperatorNode<TOp>) ?? throw new Exception("The current tree node is not an operator node.");

        public ITreeValueNode LastTreeNodeAsValueNode => (TreeNodeStack.Peek() as ITreeValueNode) ?? throw new Exception("The current tree node is not a value node.");


        public TreeVisitorContext(IExpressionTree tree)
        {
            this.Tree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>(tree.Children);
            this.TreeNodeStack.Push(Tree);
            this.ContextLeafNodes = new Stack<TLeaf>();
            this.ContextInternalNodes = new Stack<TInternal>();
            this.ContextNodes = new Stack<object>();
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
            ContextInternalNodes.Push(ctx);
            ContextNodes.Push(ContextInternalNodes.Peek());
            return this;
        }
        
        public ITreeVisitorContext<TOp, TInternal, TLeaf> Leaf (TLeaf ctx)
        {
            ContextLeafNodes.Push(ctx);
            ContextNodes.Push(ContextLeafNodes.Peek());
            return this;
        }

        
        public void Dispose()
        {
        
            if (ContextNodes.Peek() is TInternal)
            {
                ContextInternalNodes.Pop();
            }
            else if (ContextNodes.Peek() is TLeaf)
            {
                ContextLeafNodes.Pop();
            }
            ContextNodes.Pop();
        }

    }
}
