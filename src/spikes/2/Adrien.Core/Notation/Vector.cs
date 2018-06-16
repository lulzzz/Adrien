using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Vector<T> : Tensor<T> where T : unmanaged
    {
        public Vector(string name, params T[] elements) : base(name, 1) {}

        public Vector(params T[] elements) : this(vn.A, elements) { }
    }
}
