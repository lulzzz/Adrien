﻿using System;
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

}
