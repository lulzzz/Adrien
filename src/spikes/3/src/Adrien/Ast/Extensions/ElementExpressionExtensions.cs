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
    }
}
