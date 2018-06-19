using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface IExpressionTree : ITreeNode
    {
        IEnumerable<ITreeNode> Children { get; }
    }
}
