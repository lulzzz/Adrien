using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class TreeBuilderContext : TreeVisitorContext<TensorOp, OperatorNode, ValueNode>
    {
        public Stack<ITreeNode> TreeNodeStack { get; protected set; }

        public ITreeOperatorNode<TensorOp> LastTreeNodeAsOperator => (TreeNodeStack.Peek() as ITreeOperatorNode<TensorOp>) ?? throw new Exception("The current tree node is not an operator node.");

        public ITreeValueNode LastTreeNodeAsValueNode => (TreeNodeStack.Peek() as ITreeValueNode) ?? throw new Exception("The current tree node is not a value node.");

        public IEnumerable<Tensor> Tensors => this.TreeNodeStack.OfType<ITreeValueNode>().Where(n => n.NodeType == ValueNodeType.TENSOR).Select(v => v.ValueAs<Tensor>());

        public Queue<Index> TensorIndicesQueue { get; }

        public ITreeOperatorNode<TensorOp> InternalNodeAsOperatorNode => (InternalNode as ITreeOperatorNode<TensorOp>) ?? throw new Exception("The current context node is not an operator node.");

        public ExpressionTree ExpressionTree { get; }

        public TreeBuilderContext(ExpressionTree tree) : base(tree)
        {
            ExpressionTree = tree;
            this.TreeNodeStack = new Stack<ITreeNode>();
            this.TreeNodeStack.Push(Tree);
            TensorIndicesQueue = new Queue<Index>();
        }

        public T LastTreeValueNodeAs<T>()
        {
            if (LastTreeNodeAsValueNode.Value is T)
            {
                return (T)LastTreeNodeAsValueNode.Value;
            }
            else
            {
                throw new Exception($"The current tree value node is not of type {typeof(T)}.");
            }
        }

        public OperatorNode AddOperatorNode(TensorOp op)
        {
            ITreeOperatorNode<TensorOp> parent = TreeNodeStack.Count > 1 ? InternalNodeAsOperatorNode : ExpressionTree;
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
            ITreeOperatorNode<TensorOp> parent = InternalNodeAsOperatorNode;
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
