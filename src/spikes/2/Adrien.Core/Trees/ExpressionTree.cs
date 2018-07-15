using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Sawmill;
using Sawmill.Expressions;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class ExpressionTree : OperatorNode, IExpressionTree
    {
        public Expression LinqExpression { get; protected set; }

        public IEnumerable<ITreeNode> Children => HashSet.Cast<ITreeNode>();


        public ITreeNode Output => this.Left;

        public bool OutputIsTensor => (Output != null) && Output is OperatorNode;

        public Tensor OutputTensor => OutputIsTensor ? ((Output as OperatorNode).Left as ValueNode).ValueAs<Tensor>() : null;

        public int Count => HashSet.Count;

        public List<OperatorNode> OperatorNodes => this.HashSet.OfType<OperatorNode>().ToList();

        public List<ValueNode> ValueNodes => this.HashSet.OfType<ValueNode>().ToList();

        public ITreeNode Root => this;

        protected HashSet<ITreeNode> HashSet { get; } = new HashSet<ITreeNode>();

        public ExpressionTree() : base(0, null, TreeNodePosition.RIGHT, TensorOp.Assign)
        {
            HashSet.Add(this);
            AddNode(CreateValueNode(this, null));
        }

        public ExpressionTree(Tensor lhsTensor, IndexSet lhsIndices) : base(0, null, TreeNodePosition.RIGHT, TensorOp.Assign)
        {
            HashSet.Add(this);
            OperatorNode n = AddNode(CreateOperatorNode(this, TensorOp.Summation)) as OperatorNode;
            AddNode(CreateValueNode(n, lhsTensor));
            AddNode(CreateValueNode(n, lhsIndices));
        }

        public ExpressionTree(Term term) : this()
        {
            this.LinqExpression = term.LinqExpression;
        }
        
        public OperatorNode CreateOperatorNode(OperatorNode parent, TensorOp op)
        {
            TreeNodePosition pos = parent.HasLeft ? TreeNodePosition.RIGHT : TreeNodePosition.LEFT;
            int nid = pos == TreeNodePosition.LEFT ? CountChildren(parent) + 1 : CountChildren(parent) + 2;
            OperatorNode node = new OperatorNode(nid, parent.Id, pos, op);
            node.Parent = parent;
            return node;
        }

        public ValueNode CreateValueNode(OperatorNode parent, object value)
        {
            TreeNodePosition pos = parent.HasLeft ? TreeNodePosition.RIGHT : TreeNodePosition.LEFT;
            int nid = pos == TreeNodePosition.LEFT ? CountChildren(parent) + 1 : CountChildren(parent) + 2;
            ValueNode node = new ValueNode(nid, parent.Id, pos, value);
            node.Parent = parent;
            return node;
        }

        public ITreeNode AddNode(ITreeNode n)
        {
            TreeNode parent, node;
            if (n is TreeNode)
            {
                node = n as TreeNode;
            }
            else
            {
                throw new ArgumentException($"Argument node is not type TreeNode.");
            }

            if (n.Parent is TreeNode)
            {
                parent = n.Parent as TreeNode;
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
                else
                {
                    parent.Left = node;
                }
            }
            else
            {
                if (parent.HasRight)
                {
                    throw new Exception($"Parent tree node with id {parent.Id} already has a right child.");
                }
                else
                {
                    parent.Right = node;
                }
            }
            HashSet.Add(node);
            return node;
        }

        public ValueNode ValueNodeAtIndex(int index) => (HashSet.ElementAt(index) as ValueNode) ?? throw new Exception($"The element at index {index} is not a value node.");

        public OperatorNode OperatorNodeAtIndex(int index) => (HashSet.ElementAt(index) as OperatorNode) ?? throw new Exception($"The element at {index} is not an operator node.");

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
                    OperatorNode on = (OperatorNode)tn;
                    int lcount = on.Left != null ? Count(start + 1, on.Left) : start + 1;
                    int rcount = on.Right != null ? Count(lcount + 1, on.Right) : lcount;
                    return rcount;
                }
                else throw new Exception($"Unknown tree node type: {node.GetType().Name}");
            }

            return Count(0, node);
        }

        public int CountChildren() => CountChildren(this);

    }
}
