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

        public TreeNode(int id, int? parentId = null)
        {
            Id = id;
            ParentId = parentId;
        }

        public TreeNode(TreeNode parent, bool left = true)
        {
            ParentId = parent.Id;
            Id = left ? ParentId.Value + 1 : ParentId.Value + 2;
        }
    }
}
