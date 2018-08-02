using System.Collections.Generic;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorExpression Add(TensorExpression l, TensorExpression right) =>
            new TensorExpression(Expression.Add(l.LinqExpression, right.LinqExpression));

        public static TensorExpression Sub(TensorExpression l, TensorExpression right) =>
            new TensorExpression(Expression.Subtract(l.LinqExpression, right.LinqExpression));

        public static TensorExpression Mul(TensorExpression l, TensorExpression right) =>
            new TensorExpression(Expression.Multiply(l.LinqExpression, right.LinqExpression));

        public static TensorExpression Div(TensorExpression l, TensorExpression right) =>
            new TensorExpression(Expression.Divide(l.LinqExpression, right.LinqExpression));

        public static TensorExpression Square(TensorExpression l) =>
            new TensorExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Square", 1),
                Expression.Convert(l.LinqExpression, typeof(TensorExpression))));

        public static TensorExpression Sqrt(TensorExpression l) =>
            new TensorExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sqrt", 1),
                Expression.Convert(l.LinqExpression, typeof(TensorExpression))));
    }

    public partial class TensorExpression
    {
        private static TensorExpression Op_Square(TensorExpression l) => null;
        private static TensorExpression Op_Sqrt(TensorExpression l) => null;
    }
}