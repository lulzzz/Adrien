using System;
using Adrien.Ast;

namespace Adrien.Numerics
{
    /// <summary>
    /// A multi-dimensional array. Tensors are dependent
    /// on the choice of a specific backend for Adrien.
    /// </summary>
    public interface ITensor : IDisposable
    {
        ElementKind Kind { get; }

        int Count { get; }

        string Name { get; }

    }

    public interface ITensor<T> : ITensor
    {
        Memory<T> Buffer { get; }
    }
}