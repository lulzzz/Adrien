using System;

namespace Adrien.Core.Extensions
{
    public static class SymbolExtensions
    {
        public static Type ElementType(this Symbol symbol)
        {
            return symbol.Shape.Kind.GetMatchingType();
        }
    }
}
