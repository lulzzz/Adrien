using System.Collections.Generic;

namespace Adrien.Core.Extensions
{
    public static class ShapeExtensions
    {
        public static IReadOnlyList<int> Strides(this Shape shape)
        {
            var strides = new int[shape.Dimensions.Count];

            strides[strides.Length - 1] = 1;

            for (var i = strides.Length - 2; i >= 0; i--)
            {
                strides[i] = strides[i + 1] * shape.Dimensions[i];
            }

            return strides;
        }
    }
}
