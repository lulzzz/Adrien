namespace Adrien.Notation
{
    public static class TensorOperators
    {
        public static ContractionOperator Sum { get; } = new ContractionOperator((expr) => Math.SigmaSum(expr));

        public static UnaryOperator<TensorExpression, TensorExpression> Pow2 { get; } = 
            new UnaryOperator<TensorExpression, TensorExpression>((expr) => Math.Square(expr));

        public static UnaryOperator<TensorExpression, TensorExpression> Root2 { get; } = 
            new UnaryOperator<TensorExpression, TensorExpression>((expr) => Math.Sqrt(expr));

        public static UnaryOperator<TensorIndexExpression, TensorExpression> Avg { get; } = 
            new UnaryOperator<TensorIndexExpression, TensorExpression>((expr) => Math.Mean(expr));
    }
}