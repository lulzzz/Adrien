using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler;

namespace Adrien.Notation
{
    public class Vector : Tensor 
    {
        internal override Name DefaultNameBase => "V0";


        public Vector(string name) : base(name, 1) {}

        public Vector() : this(vn.V1) { }

        public Vector(string name, string indexName, out Index i) : base(name, 1)
        {
            i = new Index(null, 1, 1, indexName);
        }

        public Vector(string name, out Index i) : this(name, "i", out i) {}

        public Vector With(out Vector with)
        {
            with = new Vector(this.GenerateName(1, this.Name));
            return this;
        }

        public Var<T> Var<T>(params int[] array) where T : unmanaged => new Var<T>(this, array);
    }
}
