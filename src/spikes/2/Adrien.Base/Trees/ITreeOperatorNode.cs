using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface ITreeOperatorNode<TOp> : ITreeNode
    {
        TOp Op { get; }

        ITreeNode Left { get; set; }

        ITreeNode Right { get; set; }
    }
}
