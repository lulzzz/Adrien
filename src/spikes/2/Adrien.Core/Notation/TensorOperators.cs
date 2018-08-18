namespace Adrien.Notation
{
    public static class TensorOperators
    {
        public static ContractionOperator SUM { get; } = new ContractionOperator((expr) => Math.Sum(expr));

        public static ContractionOperator MEAN { get; } = new ContractionOperator((expr) => Math.Mean(expr));

        public static UnaryOperator<TensorExpression, TensorExpression> POW2 { get; } = 
            new UnaryOperator<TensorExpression, TensorExpression>((expr) => Math.Square(expr));

        public static UnaryOperator<TensorExpression, TensorExpression> SQRT { get; } = 
            new UnaryOperator<TensorExpression, TensorExpression>((expr) => Math.Sqrt(expr));
    }
}