using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface ITreeVisitorContext<TOp, TInternal, TLeaf> : IDisposable
    {
        IExpressionTree Tree { get; }

        Stack<TLeaf> ContextLeafNodes { get; }

        Stack<TInternal> ContextInternalNodes { get; }

        Stack<object> ContextNodes { get; }

        Stack<ITreeNode> TreeNodeStack { get; }

        TInternal InternalNode { get; }

        ITreeOperatorNode<TOp> LastTreeNodeAsOperator { get; }

        ITreeValueNode LastTreeNodeAsValueNode { get; }

        ITreeVisitorContext<TOp, TInternal, TLeaf> Internal(TInternal node);

        ITreeVisitorContext<TOp, TInternal, TLeaf> Leaf(TLeaf node);

    }
}
