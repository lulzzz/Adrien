using System;
using System.Collections.Generic;
using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class ElementExtensions
    {
        public static bool StructuralEquals(this Element element, Element other)
        {
            if (element == null && other == null)
                return true;

            if (!element.Symbol.StructuralEquals(other.Symbol))
                return false;

            if (element.Expressions.Count != other.Expressions.Count)
                return false;

            foreach (var (a, b) in element.Expressions.Zip(other.Expressions, (a, b) => (a, b)))
                if (!a.StructuralEquals(b))
                    return false;

            return true;
        }

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
                    indices.AddRange(expr.Indices());
            }

            AddElement(element);

            return indices.OrderBy(idx => idx.Name).ToList();
        }
    }
}
