using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface IExpressionTree : ITreeNode
    {
        ITreeNode Root { get; }

        IEnumerable<ITreeNode> Children { get; }

        ITreeNode Output { get; }

        bool OutputIsTensor { get; }

        ITreeNode AddNode(ITreeNode node);
    }
}
