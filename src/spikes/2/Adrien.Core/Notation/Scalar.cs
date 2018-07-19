using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Scalar : Tensor
    {
        internal override Name DefaultNameBase => "a";


        public Scalar(string name) : base(name) { }

        public Scalar() : base("a") { }


        public Scalar With(out Scalar with)
        {
            GeneratorContext = GeneratorContext.HasValue ? GeneratorContext.Value : (this, 1);
            with = new Scalar(this.GenerateName(GeneratorContext.Value.index, this.Name));
            this.GeneratorContext = (this.GeneratorContext.Value.tensor, this.GeneratorContext.Value.index + 1);
            return this.GeneratorContext.Value.tensor as Scalar;
        }
    }
}
