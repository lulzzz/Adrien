using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Vector : Tensor 
    {
        public Vector(string name) : base(name, 1) {}

        public Vector() : this(vn.V1) { }

        internal override Name DefaultNameBase => "v0";
    }
}
