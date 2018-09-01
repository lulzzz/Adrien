using System.Collections.Generic;
using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class IndexExpressionExtensions
    {
        public static bool StructuralEquals(this IndexExpression expression, IndexExpression other)
        {
            if (expression == null && other == null)
                return true;

            if (expression.ArityKind != other.ArityKind)
                return false;

            if (expression.BinaryKind != other.BinaryKind)
                return false;

            if (!expression.Index.StructuralEquals(other.Index))
                return false;

            if (expression.Constant != other.Constant)
                return false;

            if (!expression.Expr1.StructuralEquals(other.Expr1))
                return false;

            if (!expression.Expr2.StructuralEquals(other.Expr2))
                return false;

            return true;
        }

        public static IReadOnlyList<Index> Indices(this IndexExpression expression)
        {
            var indices = new HashSet<Index>();

            void AddIndexExpression(IndexExpression expr)
            {
                if (expr.Index != null) indices.Add(expr.Index);
                if (expr.Expr1 != null) AddIndexExpression(expr.Expr1);
                if (expr.Expr2 != null) AddIndexExpression(expr.Expr2);
            }

            AddIndexExpression(expression);

            return indices.OrderBy(idx => idx.Name).ToList();
        }
    }
}
