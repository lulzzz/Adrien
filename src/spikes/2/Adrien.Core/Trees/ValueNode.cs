using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;

namespace Adrien.Trees
{
    public enum ValueNodeType
    {
        TENSOR,
        INDEXSET
    }

    public class ValueNode: TreeNode
    {
        public ValueNodeType NodeType { get; internal set; }

        public object Value { get; internal set; }

        public ValueNode(int id, int? parentId, object value) : base(id, parentId)
        {
            switch (value)
            {
                case Tensor _:
                    NodeType = ValueNodeType.TENSOR;
                    break;

                case IndexSet _:
                    NodeType = ValueNodeType.INDEXSET;
                    break;

                default:
                    throw new Exception($"Unknown value type: {value.GetType().Name}.");
            }
            Value = value;
        }

        public ValueNode(ITreeOperatorNode<Op> parent, object value, TreeNodePosition pos) : this(parent.Id + (int)pos, parent.Id, value) {}
    }
}
