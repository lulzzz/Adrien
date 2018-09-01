using System;

namespace Adrien.Ast.Extensions
{
    public static class SymbolExtensions
    {
        public static bool StructuralEquals(this Symbol symbol, Symbol other)
        {
            if (symbol.Name != other.Name)
                return false;

            if (!symbol.Shape.StructuralEquals(other.Shape))
                return false;

            return true;
        }

        public static Type ElementType(this Symbol symbol)
        {
            return symbol.Shape.Kind.GetMatchingType();
        }
    }
}
