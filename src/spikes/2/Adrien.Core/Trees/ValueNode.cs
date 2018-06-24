using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class ValueNode: TreeNode
    {
        public IShape Shape { get; internal set; }

        public Tensor Value { get; internal set; }

        public ValueNode(int id, int? parentId, Tensor value) : base(id, parentId)
        {
            Value = value;
        }

        public ValueNode(OperatorNode parent, Tensor value, bool left = true) : base(parent, left)
        {
            this.Value = value;
        }
    }
}
