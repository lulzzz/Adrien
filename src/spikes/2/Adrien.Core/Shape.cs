using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public class Shape<T> //: IShape where T : unmanaged
    {
        public int[] Dimensions { get; }

        public DataType DataType { get; }

        public int Stride { get; }

        public int Rank => Dimensions.Length;

        protected virtual int[] dim { get; }
    }
}
