using System;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class BinaryOperator : IElementwiseOp
    {
        Func<TensorExpression, TensorExpression, TensorExpression> Operation;

        public BinaryOperator(Func<TensorExpression, TensorExpression, TensorExpression> op)
        {
            Operation = op;
        }

        public TensorExpression this[TensorExpression l, TensorExpression r] => Operation(l, r);

        public BinaryOperator this[UnaryOperator g] => new BinaryOperator((l, r) => this[g[l], g[r]]);

        public static BinaryOperator operator |(BinaryOperator left, UnaryOperator right) => left[right];

        public static BinaryOperator operator +(BinaryOperator left, BinaryOperator right)
        {
            return new BinaryOperator((l, r) =>
            {
                return new TensorExpression(Expression.Add(left[l, r], right[l, r]));
            });
        }

        public static BinaryOperator operator -(BinaryOperator left, BinaryOperator right)
        {
            return new BinaryOperator((l, r) =>
            {
                return new TensorExpression(Expression.Subtract(left[l, r], right[l, r]));
            });
        }

        public static BinaryOperator operator *(BinaryOperator left, BinaryOperator right)
        {
            return new BinaryOperator((l, r) =>
            {
                return new TensorExpression(Expression.Multiply(left[l, r], right[l, r]));
            });
        }

        public static BinaryOperator operator /(BinaryOperator left, BinaryOperator right)
        {
            return new BinaryOperator((l, r) =>
            {
                return new TensorExpression(Expression.Divide(left[l, r], right[l, r]));
            });
        }
    }
}