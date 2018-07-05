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
        public static TensorOp ToOp(this ExpressionType et)
        {
            switch(et)
            {
                case ExpressionType.Index:
                    return TensorOp.Summation;
                case ExpressionType.Multiply:
                    return TensorOp.Mul;
                case ExpressionType.Add: return TensorOp.Add;
                default:
                    throw new Exception($"Cannot translate expression type: {et} to tensor Op.");
            }
        }

        [DebuggerStepThrough]
        public static TExpr As<TExpr>(this Expression expr) where TExpr : Expression
        {
            return (expr as TExpr) ?? throw new Exception($"This expression {expr.ToReadableString()} is not type {typeof(TExpr).ToString()}.");
        }
    }
}
