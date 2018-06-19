using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public abstract class TreeNode : ITreeNode
    {
        public int Id { get; internal set; }

        public int? ParentId { get; internal set; }

        public bool Equals(ITreeNode other) => this.Id == other.Id;
    }
}
