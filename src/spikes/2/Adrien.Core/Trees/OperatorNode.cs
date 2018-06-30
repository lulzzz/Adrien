﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode, ITreeOperatorNode<Op>
    {
        public Op Op { get; protected set; }

        public ITreeNode Left { get; set; }

        public ITreeNode Right { get; set; }

        public override string Label => Op.ToString();


        public OperatorNode(ITreeOperatorNode<Op> parent, Op op, TreeNodePosition pos) : base(parent, pos)
        {
            Op = op;
        }

        protected OperatorNode(int id, int? parentId, Op op) : base(id, parentId)
        {
            Op = op;
        }
    }
}
