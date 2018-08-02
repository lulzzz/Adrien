using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Dimension : Vector
    {
        public Tensor Tensor { get; protected set; }

        public new int Axis { get; protected set; }

        public new int Dim { get; protected set; }

        public new int Stride { get; protected set; }

        internal Dimension(Tensor t, int axis, int dim) : base(t.Name + "_" + axis.ToString())
        {
            this.Tensor = t;
            this.Dim = dim;
            this.Stride = t.Stride[axis];
        }
    }
}
