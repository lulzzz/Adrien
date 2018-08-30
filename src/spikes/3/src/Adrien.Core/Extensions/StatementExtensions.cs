using System.Collections.Generic;
using System.Linq;

namespace Adrien.Core.Extensions
{
    public static class StatementExtensions
    {
        public static IReadOnlyList<Index> Indices(this Statement statement)
        {
            var indices = new HashSet<Index>();
            Add(indices, statement.Left);

            return indices.OrderBy(idx => idx.Name).ToList();
        }

        private static void Add(HashSet<Index> indices, ElementExpression expression)
        {
            if (expression.Element != null)
            {
                Add(indices, expression.Element);
            }

            if (expression.Expr1 != null)
            {
                Add(indices, expression.Expr1);
            }

            if (expression.Expr2 != null)
            {
                Add(indices, expression.Expr2);
            }

            if (expression.Expr3 != null)
            {
                Add(indices, expression.Expr3);
            }
        }

        private static void Add(HashSet<Index> indices, Element element)
        {
            foreach (var expr in element.Expressions)
            {
                Add(indices, expr);
            }
        }

        private static void Add(HashSet<Index> indices, IndexExpression expression)
        {
            if (expression.Index != null)
            {
                indices.Add(expression.Index);
            }

            if (expression.Expr1 != null)
            {
                Add(indices, expression.Expr1);
            }

            if (expression.Expr2 != null)
            {
                Add(indices, expression.Expr1);
            }
        }
    }
}