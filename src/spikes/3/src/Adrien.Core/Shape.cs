using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// Numeric type of a shape.
    /// </summary>
    public enum ElementKind
    {
        Boolean,
        Float32,
        Int32,
    }

    /// <summary>
    /// The shape is the geometric characterization of variables,
    /// symbols and tensors.
    /// </summary>
    public class Shape
    {
        public ElementKind Kind { get; }

        public IReadOnlyList<int> Dimensions { get; }

        public Shape(ElementKind kind, IReadOnlyList<int> dimensions)
        {
            Kind = kind;
            Dimensions = dimensions;
        }
    }

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
