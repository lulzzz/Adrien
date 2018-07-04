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

        public IEnumerable<ITreeNode> Children => Nodes.Cast<ITreeNode>();

        public int Count => Nodes.Count;

        public List<OperatorNode> OperatorNodes => this.Nodes.OfType<OperatorNode>().ToList();

        public List<ValueNode> ValueNodes => this.Nodes.OfType<ValueNode>().ToList();

        protected HashSet<ITreeNode> Nodes { get; set; }

        public ExpressionTree() : base(0, null, TensorOp.Assign)
        {
            Nodes = new HashSet<ITreeNode>();
            this.Left = new ValueNode(this, null, TreeNodePosition.LEFT, ValueNodeType.VARIABLE);
            AddNode(this.Left);
        }

        public ExpressionTree(Tensor outputTensor, IndexSet outputIndices) : base(0, null, TensorOp.Assign)
        {
            Nodes = new HashSet<ITreeNode>();
            OperatorNode n = new OperatorNode(this, TensorOp.Summation, TreeNodePosition.LEFT);
            n.Left = new ValueNode(n, outputTensor, TreeNodePosition.LEFT);
            n.Right = new ValueNode(n, outputIndices, TreeNodePosition.RIGHT);
            this.Left = n;
            AddNode(n);
        }

        public ExpressionTree(Term term) : this()
        {
            this.LinqExpression = term.LinqExpression;
        }


        public ValueNode ValueNodeAt(int index) => (Nodes.ElementAt(index) as ValueNode) ?? throw new Exception($"The node at {index} is not a value node.");

        public OperatorNode OperatorNodeAt(int index) => (Nodes.ElementAt(index) as OperatorNode) ?? throw new Exception($"The element at {index} is not an operator node.");

        public bool AddNode(ITreeNode n) => Nodes.Add(n);
 
        public int CountChildren(TreeNode node)
        {
            int Count(int start, ITreeNode tn)
            {
                if (tn is ValueNode)
                {
                    return start;
                }
                else if (tn is OperatorNode)
                {
                    OperatorNode on = (OperatorNode)tn;
                    int lcount = Count(start + 1, on.Left);
                    int rcount = on.Right != null ? Count(lcount + 1, on.Right) : lcount;
                    return rcount;
                }
                else throw new Exception("Unknown tree node type.");
            }
            return Count(0, node);
        }

        public int CountChildren() => CountChildren(this);
    }
}
