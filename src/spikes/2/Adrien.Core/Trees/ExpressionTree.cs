using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

using Adrien.Notation;

namespace Adrien.Trees
{
    public class ExpressionTree : TreeNode
    {
        public Expression Expression { get; protected set; }

        public HashSet<TreeNode> Nodes { get; protected set; } 

        public ExpressionTree(Term term)
        {
            this.Id = 0;
            Nodes = new HashSet<TreeNode>();
            this.Expression = term.LinqExpression;
        }

        public bool Build()
        {
            return false;
        }
    }
}
