using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Dimension : Vector
    {
        public Tensor Tensor { get; protected set; }

        public int Axis { get; protected set; }

        public int Length { get; protected set; }

        public int Stride { get; protected set; }

        internal Dimension(Tensor t, int axis, int length) : base(t.Label + axis.ToString())
        {
            this.Tensor = t;
            this.Length = length;
            this.Stride = t.Strides[axis];
        }
    }
}
