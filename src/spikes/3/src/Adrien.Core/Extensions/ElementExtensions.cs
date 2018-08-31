using System;

namespace Adrien.Core.Extensions
{
    public static class ElementExtensions
    {
        public static Type ElementType(this Element element)
        {
            return element.Symbol.Shape.Kind.GetMatchingType();
        }
    }
}
