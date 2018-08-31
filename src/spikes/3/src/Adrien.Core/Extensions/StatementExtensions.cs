using System;
using System.Collections.Generic;
using System.Linq;

namespace Adrien.Core.Extensions
{
    public static class StatementExtensions
    {
        public static bool StructuralEquals(this Statement statement, Statement other)
        {
            if (statement.Kind != other.Kind)
                return false;

            if (!statement.Left.StructuralEquals(other.Left))
                return false;

            if (!statement.Right.StructuralEquals(other.Right))
                return false;

            return true;
        }

        public static IReadOnlyList<Index> Indices(this Statement statement)
        {
            var indices = new HashSet<Index>();

            void AddElementExpression(ElementExpression expression)
            {
                if (expression.Element != null) indices.AddRange(expression.Element.Indices());
                if (expression.Expr1 != null) AddElementExpression(expression.Expr1);
                if (expression.Expr2 != null) AddElementExpression(expression.Expr2);
                if (expression.Expr3 != null) AddElementExpression(expression.Expr3);
            }

            indices.AddRange(statement.Left.Indices());
            AddElementExpression(statement.Right);

            return indices.OrderBy(idx => idx.Name).ToList();
        }
    }
}