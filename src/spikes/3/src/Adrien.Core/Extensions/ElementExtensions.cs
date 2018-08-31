using System;
using System.Collections.Generic;
using System.Linq;

namespace Adrien.Core.Extensions
{
    public static class ElementExtensions
    {
        public static Type ElementType(this Element element)
        {
            return element.Symbol.Shape.Kind.GetMatchingType();
        }

        public static IReadOnlyList<Index> Indices(this Element element)
        {
            var indices = new HashSet<Index>();

            void AddElement(Element elt)
            {
                foreach (var expr in elt.Expressions)
                    AddIndexExpression(expr);
            }

            void AddIndexExpression(IndexExpression expression)
            {
                if (expression.Index != null) indices.Add(expression.Index);
                if (expression.Expr1 != null) AddIndexExpression(expression.Expr1);
                if (expression.Expr2 != null) AddIndexExpression(expression.Expr2);
            }

            AddElement(element);

            return indices.OrderBy(idx => idx.Name).ToList();
        }
    }
}
