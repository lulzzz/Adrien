using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler;

namespace Adrien.Notation
{
    public class Vector : Tensor 
    {
        internal override Name DefaultNameBase => "V0";

        
        public Vector(string name, int length) : base(name, length) {}

        public Vector(int length) : this(vn.V0, length) { }

        public Vector(string name, string indexName, out Index i, int length) : base(name, length)
        {
            i = new Index(null, 1, 1, indexName);
        }

        public Vector(string name, out Index i, int length) : this(name, "i", out i, length) {}

        public Vector With(out Vector with)
        {
            GeneratorContext = GeneratorContext.HasValue ? GeneratorContext.Value : (this, 1);
            with = new Vector(this.GenerateName(GeneratorContext.Value.index, this.Name), this.Dimensions[0]);
            this.GeneratorContext = (this.GeneratorContext.Value.tensor, this.GeneratorContext.Value.index + 1);
            return this.GeneratorContext.Value.tensor as Vector;
        }

        public Vector With(out Vector with, int length)
        {

            GeneratorContext = GeneratorContext.HasValue ? GeneratorContext.Value : (this, 1);
            with = new Vector(this.GenerateName(GeneratorContext.Value.index, this.Name), length);
            this.GeneratorContext = (this.GeneratorContext.Value.tensor, this.GeneratorContext.Value.index + 1);
            return this.GeneratorContext.Value.tensor as Vector;
        }

    }
}
