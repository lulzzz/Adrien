using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IShape
    {
        int[] Dimensions { get; }

        int[] Stride { get;  }

        int Rank { get; }
    }
}
