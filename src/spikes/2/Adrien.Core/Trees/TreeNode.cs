﻿using System;
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

        public ITreeNode Parent { get; internal set; }

        public abstract string Label { get;  }


        public TreeNode(ITreeNode parent, TreeNodePosition pos) : this(parent.Id + (int) pos, parent.Id)
        {
            Parent = parent;
        }

        
        protected TreeNode(int id, int? parentId)
        {
            Id = id;
            ParentId = parentId;
        }


        public bool Equals(ITreeNode other) => this.Id == other.Id;

        
    }
}
