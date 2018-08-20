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
            var tensor = l.Tensors.Single();
            var indices = l.IndexParameters;
            Dimension mulExpr = indices.Count > 1 ?
                tensor.Dim[indices[0]] * tensor.Dim[indices[1]] : tensor.Dim[indices[0]];
            for (int i = 2; i < indices.Count; i++)
            {
                mulExpr = mulExpr * tensor.Dim[indices[i]];
            }
            return Sum(l);
            //return new TensorIndexExpression(Expression.Divide(Sum(l), mulExpr, 
            //    TensorExpression.GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(Sum(l), mulExpr)));
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
