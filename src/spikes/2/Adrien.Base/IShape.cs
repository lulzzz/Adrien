using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface IShape
    {
        DataType DataType { get; }
        int[] Dimensions { get; }
        int Stride { get;  }
        int Rank { get; }
    }
}
