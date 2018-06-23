using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Adrien;

namespace Adrien
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public Expression Expression { get; protected set; }

        public List<string> VariableNames { get; protected set; }
        public TensorExpressionVisitor(Expression expr) : base()
        {
            VariableNames = new List<string>();
            Expression = expr;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return base.VisitConstant(node);
        }
    }
}
