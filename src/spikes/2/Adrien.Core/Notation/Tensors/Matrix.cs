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

        public Matrix(string name, int rows, int columns, string indexNameBase, out Index i, out Index j) : 
            base(name, rows, columns)
        {
            i = new Index(null, 0, rows, indexNameBase);
            j = new Index(null, 1, columns, this.GenerateName(1, indexNameBase));
        }

        public Matrix(int rows, int columns, out Index i, out Index j) 
            : this(mn.A, rows, columns, "i", out i, out j) {}

        public Matrix(string name, out Index i, out Index j, int rows, int columns) 
            : this(name, rows, columns, "i", out i, out j) {}
    }
}
