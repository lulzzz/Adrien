using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode, ITreeOperatorNode<Op>
    {
        public Op Op { get; protected set; }

        public ITreeNode Left { get; protected set; }

        public ITreeNode Right { get; protected set; }

        public override string Label => Op.ToString();

        
        public OperatorNode(int id, int? parentId, Op op) : base(id, parentId)
        {
            Op = op;
        }
        

        public OperatorNode(ITreeOperatorNode<Op> parent, Op op, TreeNodePosition pos) : base(parent, pos)
        {
            Op = op;
        }

        
    }
}
