using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode, ITreeOperatorNode<TensorOp>
    {
        public TensorOp Op { get; protected set; }

        public ITreeNode Left { get; set; }

        public ITreeNode Right { get; set; }

        public override string Label => Op.ToString();


        public OperatorNode(ITreeOperatorNode<TensorOp> parent, TensorOp op, TreeNodePosition pos) : base(parent, pos)
        {
            Op = op;
        }

        protected OperatorNode(int id, int? parentId, TensorOp op) : base(id, parentId)
        {
            Op = op;
        }
    }
}
