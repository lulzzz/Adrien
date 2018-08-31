using System;
using System.Collections.Generic;

namespace Adrien.Core.Extensions
{
    public static class ShapeExtensions
    {
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
