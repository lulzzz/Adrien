using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sawmill;
using Adrien.Notation;

namespace Adrien.Trees
{
    public class ExpressionTree : OperatorNode, IExpressionTree, IEqualityComparer<ITreeNode>,
        IEqualityComparer<ITreeValueNode>
    {
        public Expression LinqExpression { get; protected set; }

        public Tensor OutputTensor => OutputNode.ValueAs<Tensor>();

        public int Count => HashSet.Count;

        public List<OperatorNode> OperatorNodes => Root.SelfAndDescendants().OfType<OperatorNode>().ToList();

        public List<ValueNode> ValueNodes => Root.SelfAndDescendants().OfType<ValueNode>().ToList();

        public ITreeNode Root => this;

        public IEnumerable<ITreeNode> Children => HashSet.Cast<ITreeNode>();

        public ITreeValueNode OutputNode
        {
            get
            {
                if (Left is ITreeValueNode)
                {
                    return Left as ITreeValueNode;
                }
                else if ((Left is OperatorNode) && (Left as OperatorNode).Op == TensorOp.Index)
                {
                    return Left.Left as ITreeValueNode;
                }
                else throw new  InvalidOperationException("The tree's output node could not be determined.");
            }
        }

        public bool OutputIsTensor => (OutputNode != null);

        public IEnumerable<ITreeValueNode> TensorNodes => ValueNodes.Where(vn => vn.NodeType == ValueNodeType.TENSOR);

        public IEnumerable<ITreeValueNode> IndexSetNodes =>
            ValueNodes.Where(vn => vn.NodeType == ValueNodeType.INDEXSET);

        public IEnumerable<ITreeValueNode> VariableNodes =>
            OperatorNodes
                .Where(on => on.Op == TensorOp.ElementWiseAssign)
                .Select(on => on.Left)
                .Cast<ITreeValueNode>()
                .Distinct(this);


        protected HashSet<ITreeNode> HashSet { get; } = new HashSet<ITreeNode>();

        public ExpressionTree() : base(0, null, TreeNodePosition.RIGHT, TensorOp.Assign)
        {
            HashSet.Add(this);
            AddNode(CreateValueNode(this, null));
        }

        public ExpressionTree(Term term) : this()
        {
            LinqExpression = term.LinqExpression;
        }

        public ExpressionTree(Tensor lhsTensor, IndexSet lhsTensorIndices) : base(0, null, TreeNodePosition.RIGHT,
            TensorOp.Assign)
        {
            HashSet.Add(this);
            if (lhsTensorIndices == null)
            {
                AddNode(CreateValueNode(this, lhsTensor));
            }
            else
            {
                var n = AddNode(CreateOperatorNode(this, TensorOp.Index)) as OperatorNode;
                AddNode(CreateValueNode(n, lhsTensor));
                AddNode(CreateValueNode(n, lhsTensorIndices));
            }
        }

        public OperatorNode CreateOperatorNode(OperatorNode parent, TensorOp op)
        {
            var pos = parent.HasLeft ? TreeNodePosition.RIGHT : TreeNodePosition.LEFT;
            var nid = pos == TreeNodePosition.LEFT ? CountChildren(parent) + 1 : CountChildren(parent) + 2;
            var node = new OperatorNode(nid, parent.Id, pos, op);
            node.Parent = parent;
            return node;
        }

        public ValueNode CreateValueNode(OperatorNode parent, object value)
        {
            var pos = parent.HasLeft ? TreeNodePosition.RIGHT : TreeNodePosition.LEFT;
            var nid = pos == TreeNodePosition.LEFT ? CountChildren(parent) + 1 : CountChildren(parent) + 2;
            var node = new ValueNode(nid, parent.Id, pos, value);
            node.Parent = parent;
            return node;
        }

        public ITreeNode AddNode(ITreeNode n)
        {
            TreeNode parent, node;
            if (n is TreeNode treeNode)
            {
                node = treeNode;
            }
            else
            {
                throw new ArgumentException($"Argument node is not type TreeNode.");
            }

            if (n.Parent is TreeNode parentNode)
            {
                parent = parentNode;
            }
            else
            {
                throw new ArgumentException($"Argument node's parent is not type TreeNode.");
            }

            if (node.Position == TreeNodePosition.LEFT)
            {
                if (parent.HasLeft)
                {
                    throw new Exception($"Parent tree node with id {parent.Id} already has a left child.");
                }

                parent.Left = node;
            }
            else
            {
                if (parent.HasRight)
                {
                    throw new Exception($"Parent tree node with id {parent.Id} already has a right child.");
                }

                parent.Right = node;
            }

            HashSet.Add(node);
            return node;
        }

        public ValueNode ValueNodeAtIndex(int index) => (ValueNode)HashSet.ElementAt(index);

        public OperatorNode OperatorNodeAtIndex(int index) => (OperatorNode)HashSet.ElementAt(index);

        public int CountChildren(TreeNode node)
        {
            int Count(int start, ITreeNode tn)
            {
                if (tn is null || tn is ValueNode)
                {
                    return start;
                }
                else if (tn is OperatorNode)
                {
                    var on = (OperatorNode) tn;
                    var lcount = on.Left != null ? Count(start + 1, on.Left) : start + 1;
                    var rcount = on.Right != null ? Count(lcount + 1, on.Right) : lcount;
                    return rcount;
                }
                else throw new NotSupportedException($"Unknown tree node type: {node.GetType().Name}.");
            }

            return Count(0, node);
        }

        public int CountChildren() => CountChildren(this);

        public int GetHashCode(ITreeNode node)
        {
            return node.Label.GetHashCode();
        }

        public bool Equals(ITreeNode left, ITreeNode right)
        {
            return left.Label == right.Label;
        }

        public int GetHashCode(ITreeValueNode node)
        {
            return node.NodeType.GetHashCode() ^ node.Label.GetHashCode();
        }

        public bool Equals(ITreeValueNode left, ITreeValueNode right)
        {
            return (left.NodeType == right.NodeType) && (left.Label == right.Label);
        }
    }
}