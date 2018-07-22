using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Adrien.Compiler
{
    public interface IVariable<T> : IEnumerable<T>, INDArray, IPinnable where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        bool Initialized { get; }

        int[] Dimensions { get; }

        int[] Stride { get; }

        int Rank { get; }

        MemoryHandle MemoryHandle { get; }

        ref T Read(int index);

        void Write(int index, T value);

        ref T this[int index] { get; }

        Span<T> Span { get; }
    }
}

