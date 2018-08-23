using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class Scalar : Tensor
    {
        internal override Name DefaultNameBase => "a";

        public object Value { get; protected set; }

        public Scalar(string name) : base(name, 1)
        {
           
        }

        public Scalar() : this("a")
        {
        }

        public Scalar(string name, object value) : this(name)
        {
            Value = value;
        }

        public Scalar(string name, TensorIndexExpression expr) : this(name)
        {
            this.ContractionDefinition = (null, new TensorContraction(expr, this));
        }

        public Scalar With(out Scalar with)
        {
            int nameGeneratorStartIndex = 1;
            // TODO: [vermorel]  '1' magic number needs clarification.
            // REMARK: [allisterb] Use nameGeneratorStartIndex variable.
            GeneratorContext = GeneratorContext ?? (this, nameGeneratorStartIndex); 
            with = new Scalar(GenerateName(GeneratorContext.Value.index, Name));
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor as Scalar;
        }
    }
}