using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface IExpressionTree : ITreeNode
    {
        ITreeNode Root { get; }

        IEnumerable<ITreeNode> Children { get; }

        bool AddNode(ITreeNode n);
    }
}
