using System;
using System.Buffers;
using System.Collections.Generic;

using System.Text;

namespace Adrien.Compiler
{
    public interface IVariable<T> where T : unmanaged
    {
        string Name { get; }
       
        int[] Dimensions { get; }

        int Rank { get; }

        int Size { get; }

        MemoryHandle Handle { get; }

        bool Initialized { get; }
    }
}

