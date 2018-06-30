﻿using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class ValueNode: TreeNode, ITreeValueNode
    {
        public ValueNodeType NodeType { get; internal set; }

        public object Value { get; internal set; }

        public override string Label
        {
            get
            {
                switch (this.Value)
                {
                    case Term t: return t.Name;
                    default: throw new Exception($"Unknown value: {Value}.");
                }
            }
        }


        public ValueNode(ITreeOperatorNode<Op> parent, object value, TreeNodePosition pos) : this(parent.Id + (int)pos, parent.Id, value)
        {
            Parent = parent;
        }

        protected ValueNode(int id, int? parentId, object value) : base(id, parentId)
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


        public T ValueAs<T>() where T : class
        {
            return (Value as T) ?? throw new Exception();
        }

 
    }
}
