using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public abstract class TreeNode : ITreeNode
    {
        public int Id { get; internal set; }

        public int? ParentId { get; internal set; }

        public ITreeNode Parent { get; internal set; }

        public TreeNodePosition Position { get; internal set; }

        public abstract string Label { get; }

        public ITreeNode Left { get; internal set; }

        public ITreeNode Right { get; internal set; }

        public bool IsOperator => this is OperatorNode;

        public bool IsValue => this is ValueNode;

        public bool HasLeft => this is OperatorNode && (this as OperatorNode).Left != null;

        public bool HasRight => this is OperatorNode && (this as OperatorNode).Right != null;
 
        protected TreeNode(int id, int? parentId, TreeNodePosition pos)
        {
            Id = id;
            ParentId = parentId;
            Position = pos;
        }


        public bool Equals(ITreeNode other) => this.Id == other.Id;

        
    }
}
