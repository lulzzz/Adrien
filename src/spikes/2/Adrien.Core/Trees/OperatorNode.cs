using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode, ITreeOperatorNode<TensorOp>
    {
        public TensorOp Op { get; protected set; }

        public override string Label => Op.ToString();

        /*
        public OperatorNode(ITreeOperatorNode<TensorOp> parent, TensorOp op, TreeNodePosition pos) : base(parent, pos)
        {
            Op = op;
        }
        */
        internal OperatorNode(int id, int? parentId, TreeNodePosition pos, TensorOp op) : base(id, parentId, pos)
        {
            Op = op;
        }
    }
}
