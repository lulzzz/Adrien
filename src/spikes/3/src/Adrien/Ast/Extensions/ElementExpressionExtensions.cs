using System.Collections.Generic;
using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class ElementExpressionExtensions
    {
        public static bool StructuralEquals(this ElementExpression expr, ElementExpression other)
        {
            if (expr == null && other == null)
                return true;

            if (expr.ArityKind != other.ArityKind)
                return false;

            if (expr.UnaryKind != other.UnaryKind)
                return false;

            if (expr.BinaryKind != other.BinaryKind)
                return false;

            if (!expr.Element.StructuralEquals(other.Element))
                return false;

            if (!expr.Expr1.StructuralEquals(other.Expr1))
                return false;

            if (!expr.Expr2.StructuralEquals(other.Expr2))
                return false;

            if (!expr.Expr3.StructuralEquals(other.Expr3))
                return false;

            return true;
        }

        public static IReadOnlyList<Symbol> Symbols(this ElementExpression expr)
        {
            var symbols = new HashSet<Symbol>();

            if (expr.Element != null)
                symbols.AddRange(expr.Element.Symbols());

            if(expr.Expr1 != null)
                symbols.AddRange(expr.Expr1.Symbols());

            if (expr.Expr2 != null)
                symbols.AddRange(expr.Expr2.Symbols());

            if (expr.Expr3 != null)
                symbols.AddRange(expr.Expr3.Symbols());

            return symbols.OrderBy(s => s.Position).ToList();
        }
    }
}
