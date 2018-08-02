using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AgileObjects.ReadableExpressions;
using Sawmill.Expressions;
using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Expressions
{
    public static class ExpressionExtensions
    {
        [DebuggerStepThrough]
        public static TensorOp ToOp(this ExpressionType et)
        {
            switch (et)
            {
                case ExpressionType.Index: return TensorOp.Index;
                case ExpressionType.Multiply: return TensorOp.Mul;
                case ExpressionType.Add: return TensorOp.Add;
                case ExpressionType.Subtract: return TensorOp.Sub;
                case ExpressionType.Power: return TensorOp.Pow;
                default:
                    throw new NotSupportedException($"Cannot translate expression type: {et} to TensorOp.");
            }
        }

        [DebuggerStepThrough]
        public static TExpr As<TExpr>(this Expression expr) where TExpr : Expression
        {
            return (expr as TExpr) ??
                   throw new NotSupportedException(
                       $"This expression {expr.ToReadableString()} is not type {typeof(TExpr)}.");
        }

        [DebuggerStepThrough]
        public static List<T> GetConstants<T>(this Expression expr) where T : ITerm
        {
            var c0 = expr.DescendantsAndSelf()
                .OfType<ConstantExpression>()
                .Where(e => e.Type == typeof(T))
                .Select(e => (T) e.Value);

            return expr.DescendantsAndSelf()
                .OfType<ConstantExpression>()
                .Where(e => e.Type.BaseType == typeof(Array)
                            && e.Type.HasElementType
                            && e.Type.GetElementType() == typeof(Tensor))
                .Select(e => e.Value)
                .Cast<Array>()
                .Select(a => a.Flatten<T>().First())
                .Concat(c0)
                .ToList();
        }

        [DebuggerStepThrough]
        public static List<T> GetIndexObjects<T>(this Expression expr) where T : ITerm
        {
            return expr.DescendantsAndSelf()
                .OfType<IndexExpression>()
                .Select(e => e.Object)
                .Cast<Array>()
                .Select(a => a.Flatten<T>().First())
                .ToList();
        }

        [DebuggerStepThrough]
        public static TensorOp MethodCallToTensorOp(this MethodCallExpression expr)
        {
            switch (expr.Method.Name)
            {
                case "Op_Sum": return TensorOp.Sum;
                case "Op_Square": return TensorOp.Square;
                case "Op_Sqrt": return TensorOp.Sqrt;
                default: throw new NotImplementedException();
            }
        }
    }
}