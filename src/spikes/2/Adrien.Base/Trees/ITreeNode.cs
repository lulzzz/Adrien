using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface ITreeNode : IEquatable<ITreeNode>
    {
        int Id { get; }

        int? ParentId { get; }

        ITreeNode Parent { get; }

        string Label { get; }
    }
}
