using System.Collections.Generic;
using System.Linq;

namespace Adrien.Core.Extensions
{
    public static class StatementExtensions
    {
        public static IReadOnlyList<Index> Indices(this Statement statement)
        {
            var indices = new HashSet<Index>();

            void AddElementExpression(ElementExpression expression)
            {
                if (expression.Element != null) AddElement(expression.Element);
                if (expression.Expr1 != null) AddElementExpression(expression.Expr1);
                if (expression.Expr2 != null) AddElementExpression(expression.Expr2);
                if (expression.Expr3 != null) AddElementExpression(expression.Expr3);
            }

            void AddElement(Element element)
            {
                foreach (var expr in element.Expressions)
                    AddIndexExpression(expr);
            }

            void AddIndexExpression(IndexExpression expression)
            {
                if (expression.Index != null) indices.Add(expression.Index);
                if (expression.Expr1 != null) AddIndexExpression(expression.Expr1);
                if (expression.Expr2 != null) AddIndexExpression(expression.Expr2);
            }

            AddElement(statement.Left);
            AddElementExpression(statement.Right);

            return indices.OrderBy(idx => idx.Name).ToList();
        }
    }
}