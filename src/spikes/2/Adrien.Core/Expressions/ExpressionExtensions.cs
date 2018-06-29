using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

using AgileObjects.ReadableExpressions;

namespace Adrien.Trees
{
    public static class ExpressionExtensions
    {
        [DebuggerStepThrough]
        public static Op ToOp(this ExpressionType et)
        {
            switch(et)
            {
                case ExpressionType.Index:
                    return Op.Summation;
                default:
                    throw new Exception($"Unknown expression type: {et}.");
            }
        }

        [DebuggerStepThrough]
        public static TExpr As<TExpr>(this Expression expr) where TExpr : Expression
        {
            return (expr as TExpr) ?? throw new Exception($"This expression {expr.ToReadableString()} is not type {typeof(TExpr).ToString()}.");
        }
    }
}
