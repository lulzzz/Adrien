using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface ITreeVisitorContext<TOp, TTreeNode> : IDisposable
    {
        IExpressionTree Tree { get; }

        Stack<TTreeNode> Operands { get; }

        Stack<TOp> Operators { get; }

        Stack<object> O { get; }

        Stack<ITreeNode> TreeNodeStack { get; }

        TOp CurrentOp { get; }

        ITreeOperatorNode<TOp> LastTreeNodeAsOperator { get; }

        ITreeValueNode LastTreeNodeAsValueNode { get; }

        ITreeVisitorContext<TOp, TTreeNode> Operation(TOp op);

        ITreeVisitorContext<TOp, TTreeNode> Operand(TTreeNode operand);

    }
}
