using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode
    {
        public Op Op { get; protected set; }

        public TreeNode Left { get; protected set; }

        public TreeNode Right { get; protected set; }

        public OperatorNode(int id, int? parentId, Op op) : base(id, parentId)
        {
            Op = op;
        }

        public OperatorNode(OperatorNode parent, Op op, TreeNodePosition pos) : base(parent, pos)
        {
            Op = op;
        }
    }
}
