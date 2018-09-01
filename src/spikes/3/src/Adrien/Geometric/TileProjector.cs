using System;
using System.Collections.Generic;
using System.Linq;
using Adrien.Ast;
using Adrien.Ast.Extensions;

namespace Adrien.Geometric
{
    /// <summary>
    /// Intended to simplify backend implementations of Adrien.
    /// Transform all complex indices into simple ones.
    /// </summary>
    /// <remarks>
    /// Just like a mathematical projection, the application of the
    /// projector is idempotent, i.e. re-projecting a tile yields the
    /// same tile.
    /// </remarks>
    public static class TileProjector
    {
        /// <summary>Transform all complex indices into simple ones.</summary>
        public static Tile Project(this Tile tile)
        {
            if (!tile.Statements.Any(s => s.Indices().Any(i => i.IsComplex())))
            {
                return tile;
            }

            var statements = tile.Statements.Select(Project).ToList();
            return new Tile(tile.Name, statements);
        }

        private static Statement Project(Statement statement)
        {
            return new Statement(statement.Kind, 
                Project(statement.Left),
                Project(statement.Right));            
        }

        private static Element Project(Element element)
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
                        simple.Range = complex.Ranges[i];
                        list.Add(Project(expr, complex, simple));
                    }
                }
            }

            return new Element(element.Symbol, list);
        }

        private static ElementExpression Project(ElementExpression expr)
        {
            switch (expr.ArityKind)
            {
                case ArityKind.Element:
                    return new ElementExpression(Project(expr.Element));
                case ArityKind.Unary:
                    return new ElementExpression(expr.UnaryKind, Project(expr.Expr1));
                case ArityKind.Binary:
                    return new ElementExpression(expr.BinaryKind, Project(expr.Expr1), Project(expr.Expr2));
                case ArityKind.Ternary:
                    return new ElementExpression(Project(expr.Expr1), Project(expr.Expr2), Project(expr.Expr3));
                default:
                    throw new NotSupportedException();
            }
        }

        private static IndexExpression Project(IndexExpression expr, Index complex, Index simple)
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
                        Project(expr.Expr1, complex, simple),
                        Project(expr.Expr2, complex, simple));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
