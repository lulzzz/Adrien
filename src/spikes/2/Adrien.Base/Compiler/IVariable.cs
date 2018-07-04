using System;
using System.Collections.Generic;

using System.Text;

namespace Adrien.Compiler
{
    public interface IVariable<T> where T : unmanaged
    {
        string Name { get; }
       
        int[] Dimensions { get; }

        int Rank { get; }

        Memory<T> Memory { get; }

        bool Initialized { get; }
    }
}

