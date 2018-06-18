using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface IShape<T> where T : unmanaged
    {
        int[] Dimensions { get; }
        int Stride { get;  }
        int Rank { get; }
    }
}
