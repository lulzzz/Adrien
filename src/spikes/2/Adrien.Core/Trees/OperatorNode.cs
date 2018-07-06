using System;
using System.Collections.Generic;
using System.Text;

using Sawmill;
namespace Adrien.Trees
{
    public class OperatorNode : TreeNode, ITreeOperatorNode<TensorOp>
    {
        public TensorOp Op { get; protected set; }

        public override string Label => Op.ToString();

        internal OperatorNode(int id, int? parentId, TreeNodePosition pos, TensorOp op) : base(id, parentId, pos)
        {
            Op = op;
        }

        public override Children<ITreeNode> GetChildren() => Children.Two(Left, Right);

        public override ITreeNode SetChildren(Children<ITreeNode> newChildren)
        {
            this.Left = newChildren.First;
            this.Right = newChildren.Second;
            return this;
        }
    }
}
