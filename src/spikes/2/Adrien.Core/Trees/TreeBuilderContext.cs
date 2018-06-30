using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class TreeBuilderContext : TreeVisitorContext<Op, OperatorNode, ValueNode>
    {
        public IEnumerable<Tensor> Tensors => this.TreeNodeStack.OfType<ITreeValueNode>().Where(n => n.NodeType == ValueNodeType.TENSOR).Select(v => v.ValueAs<Tensor>());

        public Queue<Index> TensorIndicesQueue { get; }

        public ITreeOperatorNode<Op> InternalNodeAsOperatorNode => (InternalNode as ITreeOperatorNode<Op>) ?? throw new Exception("The current context node is not an operator node.");

        public ExpressionTree ExpressionTree { get; }

        public TreeBuilderContext(ExpressionTree tree) : base(tree)
        {
            ExpressionTree = tree;
            TensorIndicesQueue = new Queue<Index>();
        }


        public OperatorNode AddOperatorNode(Op op)
        {
            ITreeOperatorNode<Op> parent = TreeNodeStack.Count > 1 ? InternalNodeAsOperatorNode : ExpressionTree;
            TreeNodePosition pos = parent.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            OperatorNode on = new OperatorNode(parent, op, pos);
            if (pos == TreeNodePosition.LEFT)
            {
                parent.Left = on;
            }
            else
            {
                parent.Right = on;
            }
            this.Tree.AddNode(on);
            this.TreeNodeStack.Push(on);
            return on;
        }

        public ValueNode AddValueNode(object value)
        {
            if (value is Tensor && TensorIndicesQueue.Count > 0)
            {
                Tensor t = value as Tensor;
                throw new Exception($"Attempting to add new value node for Tensor {t.Name} but the tensor indices queue still has {TensorIndicesQueue.Count} elements and last element: {TensorIndicesQueue.Peek().Name}");
            }
            ITreeOperatorNode<Op> parent = InternalNodeAsOperatorNode;
            TreeNodePosition pos = parent.Left == null ? TreeNodePosition.LEFT : TreeNodePosition.RIGHT;
            ValueNode vn = new ValueNode(parent, value, pos);
            if (pos == TreeNodePosition.LEFT)
            {
                parent.Left = vn;
            }
            else
            {
                parent.Right = vn;
            }
            this.Tree.AddNode(vn);
            this.TreeNodeStack.Push(vn);
            return vn;
        }
    }
}
