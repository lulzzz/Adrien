using System;
using System.Collections.Generic;

namespace Adrien.Core.Numeric
{
    /// <summary>
    /// A multi-dimensional array. Tensors are dependent
    /// on the choice of a specific backend for Adrien.
    /// </summary>
    public interface ITensor : IDisposable
    {
        ElementKind Kind { get; }

        int Rank { get; }

        IReadOnlyList<int> Dimensions { get; }

        string Name { get; }

        void Read<T>(Span<T> into, int offset);

        void Write<T>(Span<T> from, int offset);
    }
}