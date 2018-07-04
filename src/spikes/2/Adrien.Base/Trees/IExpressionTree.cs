using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface IExpressionTree : ITreeNode
    {
        IEnumerable<ITreeNode> Children { get; }
        bool AddNode(ITreeNode n);
    }
}
