using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public enum TreeNodePosition
    {
        LEFT = 1,
        RIGHT = 2
    }

    public abstract class TreeNode : ITreeNode
    {
        public int Id { get; internal set; }

        public int? ParentId { get; internal set; }


        public TreeNode(int id, int? parentId = null)
        {
            Id = id;
            ParentId = parentId;
        }

        public TreeNode(TreeNode parent, TreeNodePosition pos) : this(parent.Id + (int) pos, parent.Id)
        {
        }


        public bool Equals(ITreeNode other) => this.Id == other.Id;

        
    }
}
