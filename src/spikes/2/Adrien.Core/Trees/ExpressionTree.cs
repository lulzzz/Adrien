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

        public HashSet<TreeNode> Nodes { get; protected set; }

        public IEnumerable<ITreeNode> Children => Nodes.Cast<ITreeNode>();


        public ExpressionTree() : base(0, null, Op.Assign)
        {
            Nodes = new HashSet<TreeNode>();
        }

        public ExpressionTree(Term term) : this()
        {
            this.LinqExpression = term.LinqExpression;
        }

        public int CountChildren(TreeNode node)
        {
            int Count(int start, TreeNode tn)
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
