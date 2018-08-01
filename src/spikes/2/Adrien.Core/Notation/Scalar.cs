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

        public Scalar(object value) : this("__value")
        {
            Value = value;
        }

        public Scalar With(out Scalar with)
        {
            GeneratorContext = GeneratorContext ?? (this, 1); // TODO: [vermorel]  '1' magic number needs clarification.
            with = new Scalar(GenerateName(GeneratorContext.Value.index, Name));
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor as Scalar;
        }
    }
}