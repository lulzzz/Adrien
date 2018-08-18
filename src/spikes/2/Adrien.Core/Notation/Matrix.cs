using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Matrix : Tensor
    {
        internal override Name DefaultNameBase => "A";

        protected Matrix(string name) : base(name) {}

        public Matrix(string name, int rows, int columns) : base(name, rows, columns) {}

        public Matrix(int rows, int columns) : this(mn.A, rows, columns) {}

        public Matrix(string name, string indexNameBase, out Index i0, out Index i1, int rows, int columns) : 
            base(name, rows, columns)
        {
            i0 = new Index(null, 0, rows, indexNameBase);
            i1 = new Index(null, 1, columns, this.GenerateName(1, indexNameBase));
        }

        public Matrix(int rows, int columns, out Index i0, out Index i1) 
            : this(mn.A, "i", out i0, out i1, rows, columns) {}

        public Matrix(string name, out Index i0, out Index i1, int rows, int columns) 
            : this(name, "i", out i0, out i1, rows, columns) {}
    }
}
