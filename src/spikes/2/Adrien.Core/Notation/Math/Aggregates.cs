using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorIndexExpression Sum(TensorIndexExpression l) => 
            new TensorIndexExpression(GetOpMethodCall("Sum", l));

        public static TensorIndexExpression Mean(TensorIndexExpression l)
        {
            var tensor = (Tensor) l;
            var indices = l.IndexParameters;
            var mulExpr = tensor.GetDimensionProductExpression(indices);
            return Sum(l) / mulExpr;
        }

        private static MethodCallExpression GetOpMethodCall(string op, params TensorIndexExpression[] args)
        {
            return Expression.Call(TensorExpression.GetOpMethodInfo<TensorIndexExpression>("Op_" + op, args.Length),
                args.Select(a => Expression.Convert(a, typeof(TensorIndexExpression))).ToArray());
        }
    }

    public partial class TensorExpression
    {
        private static TensorIndexExpression Op_Sum(TensorIndexExpression l) => null;
        private static TensorIndexExpression Op_Mean(TensorIndexExpression l) => null;
    }
}
