using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public ExpressionTree Tree { get; set; }

        internal Expression Expr;

        internal TreeNode CurrentNode { get; set; }

        public TensorExpressionVisitor(Expression expr) : base()
        {
            Expr = expr;
            CurrentNode = Tree = new ExpressionTree();
        }

        internal static TReturn FlattenConstantExpressionValue<TReturn>(ConstantExpression node)
        {
            Array a = (Array)node.Value;
            return a.Flatten<TReturn>().First();
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            ValueNode v = null;
            if (CurrentNode is ValueNode)
            {
                throw new InvalidOperationException("The current expression tree node is not an operator node.");
            }
            if (node.Value is Array)
            {
                v = new ValueNode((OperatorNode)CurrentNode, FlattenConstantExpressionValue<Tensor>(node));
            }
            else throw new InvalidOperationException($"Can't convert ConstantExpression {node.Value.GetType().Name} to Tensor.");

            if (Tree.Nodes.Add(v))
            {
                CurrentNode = v;
                return base.VisitConstant(node);
            }
            else
            {
                throw new Exception("Could not add value node to expression tree.");
            }
                            
        }

        public void Visit()
        {
            this.Visit(Expr);
        }

    }
}
