using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public class TensorShape<T> : IShape<T> where T : unmanaged
    {
        public int[] Dimensions { get; protected set; }

        public int Rank => Dimensions.Length;

        public int Stride { get; protected set; }

        public TensorShape(params int[] dim)
        {
            Dimensions = dim;
        }
    }
}
