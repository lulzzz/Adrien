using System;

namespace Adrien.Ast.Extensions
{
    public static class ElementKindExtensions
    {
        public static Type GetMatchingType(this ElementKind kind)
        {
            switch (kind)
            {
                case ElementKind.Boolean:
                    return typeof(bool);
                case ElementKind.Float32:
                    return typeof(float);
                case ElementKind.Int32:
                    return typeof(int);
            }

            throw new NotSupportedException();
        }

        public static ElementKind GetMatchingElementKind(this Type type)
        {
            if (typeof(bool) == type)
                return ElementKind.Boolean;

            if (typeof(float) == type)
                return ElementKind.Float32;

            if (typeof(int) == type)
                return ElementKind.Int32;

            throw new NotSupportedException();
        }
    }
}