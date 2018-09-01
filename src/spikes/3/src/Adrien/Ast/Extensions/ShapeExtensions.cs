using System;
using System.Collections.Generic;
using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class ShapeExtensions
    {
        public static bool StructuralEquals(this Shape shape, Shape other)
        {
            if (shape.Kind != other.Kind)
                return false;

            if (shape.Dimensions.Count != other.Dimensions.Count)
                return false;

            foreach (var (a, b) in shape.Dimensions.Zip(other.Dimensions, (a, b) => (a, b)))
                if (a != b)
                    return false;

            return true;
        }

        public static int ElementCount(this Shape shape)
        {
            var count = 1;
            for (var i = 0; i < shape.Dimensions.Count; i++)
                count *= shape.Dimensions[i];

            return count;
        }

        public static Type ElementType(this Shape shape)
        {
            return shape.Kind.GetMatchingType();
        }

        public static IReadOnlyList<int> Strides(this Shape shape)
        {
            var strides = new int[shape.Dimensions.Count];

            strides[strides.Length - 1] = 1;

            for (var i = strides.Length - 2; i >= 0; i--)
            {
                strides[i] = strides[i + 1] * shape.Dimensions[i + 1];
            }

            return strides;
        }
    }
}
