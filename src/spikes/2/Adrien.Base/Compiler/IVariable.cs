using System;
using System.Buffers;
using System.Collections.Generic;

using System.Text;

namespace Adrien.Compiler
{
    public interface IVariable<T> : INDArray<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        string Name { get; }
       
        int[] Dimensions { get; }

        int Rank { get; }

        MemoryHandle Handle { get; }

        bool Initialized { get; }

        ref T Read(int index);

        void Write(int index, T value);

        ref T this[int index] { get; }
    }
}

