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


        public ExpressionTree() : base(0, null, Op.Add)
        {
            Nodes = new HashSet<TreeNode>();
        }

        public ExpressionTree(Term term) : this()
        {
            this.LinqExpression = term.LinqExpression;
        }

 
        public bool Build()
        {
            LinqExpression.DescendantsAndSelf().OfType<ConstantExpression>();
            return false;
            
        }
    }
}
