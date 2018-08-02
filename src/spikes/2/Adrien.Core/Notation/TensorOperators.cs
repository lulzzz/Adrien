namespace Adrien.Notation
{
    public static class TensorOperators
    {
        public static BinaryOperator Add { get; } = new BinaryOperator((l, r) => Math.Add(l, r));
        public static BinaryOperator Sub { get; } = new BinaryOperator((l, r) => Math.Sub(l, r));

        public static UnaryOperator Pow2 { get; } = new UnaryOperator((expr) => Math.Square(expr));
        public static UnaryOperator Root2 { get; } = new UnaryOperator((expr) => Math.Sqrt(expr));

        public static ContractionOperator Sum { get; } = new ContractionOperator((expr) => Math.SigmaSum(expr));
        public static ContractionOperator Avg { get; } = new ContractionOperator((expr) => Math.Mean(expr));
    }
}