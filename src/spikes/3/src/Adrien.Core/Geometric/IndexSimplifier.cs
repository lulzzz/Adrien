using System;
using System.Collections.Generic;
using System.Linq;
using Adrien.Core.Extensions;

namespace Adrien.Core.Geometric
{
    public static class IndexSimplifier
    {
        /// <summary>Transform all complex indices into simple ones.</summary>
        public static Tile SimplifyIndices(this Tile tile)
        {
            if (!tile.Statements.Any(s => s.Indices().Any(i => i.IsComplex())))
            {
                return tile;
            }

            var simplified = new Tile(tile.Name);

            foreach (var input in tile.Inputs)
            {
                simplified.AddInput(input);
            }

            foreach (var output in tile.Outputs)
            {
                simplified.AddOutput(output);
            }

            foreach (var statement in tile.Statements)
            {
                simplified.Add(Simplify(statement));
            }

            return simplified;
        }

        private static Statement Simplify(Statement statement)
        {
            return new Statement(statement.Kind, 
                Simplify(statement.Left),
                Simplify(statement.Right));            
        }

        private static Element Simplify(Element element)
        {
            var allIndices = element.Indices();
            if (!allIndices.Any(i => i.IsComplex()))
                return element;

            var list = new List<IndexExpression>();
            foreach (var expr in element.Expressions)
            {
                var indices = expr.Indices();
                if (!indices.Any(i => i.IsComplex()))
                {
                    list.Add(expr);
                }
                else
                {
                    // at most, a single complex index
                    var complex = indices.First(i => i.IsComplex());
                    for (var i = 0; i < complex.Ranges.Count; i++)
                    {
                        var simple = new Index(complex.Name + "_" + i);
                        simple.Ranges = new[] { complex.Ranges[i] };
                        list.Add(Simplify(expr, complex, simple));
                    }
                }
            }

            return new Element(element.Symbol, list);
        }

        private static ElementExpression Simplify(ElementExpression expr)
        {
            switch (expr.ArityKind)
            {
                case ArityKind.Element:
                    return new ElementExpression(Simplify(expr.Element));
                case ArityKind.Unary:
                    return new ElementExpression(expr.UnaryKind, Simplify(expr.Expr1));
                case ArityKind.Binary:
                    return new ElementExpression(expr.BinaryKind, Simplify(expr.Expr1), Simplify(expr.Expr2));
                case ArityKind.Ternary:
                    return new ElementExpression(Simplify(expr.Expr1), Simplify(expr.Expr2), Simplify(expr.Expr3));
                default:
                    throw new NotSupportedException();
            }
        }

        private static IndexExpression Simplify(IndexExpression expr, Index complex, Index simple)
        {
            switch (expr.ArityKind)
            {
                case IndexExpressionArityKind.Constant:
                    return expr;
                case IndexExpressionArityKind.Index:
                    if(expr.Index.Name == complex.Name)
                        return new IndexExpression(simple);
                    return expr;
                case IndexExpressionArityKind.Binary:
                    return new IndexExpression(expr.BinaryKind, 
                        Simplify(expr.Expr1, complex, simple),
                        Simplify(expr.Expr2, complex, simple));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
