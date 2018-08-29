using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// Numeric type of a shape.
    /// </summary>
    public enum ElementKind
    {
        Int16,
        Int32,
        Int64,
        Float16,
        Float32,
        Float64
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
}
