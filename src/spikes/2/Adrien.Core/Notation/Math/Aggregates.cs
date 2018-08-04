using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorContraction SigmaSum(TensorIndexExpression l) =>
         new TensorContraction(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sum", 1),
             Expression.Convert(l.LinqExpression, typeof(TensorExpression))), l.Bounds);

        public static TensorContraction Mean(TensorIndexExpression l)
        {
            return null;
            //new TensorContraction(Expression.Divide(SigmaSum(l), l);
        }
    }

    public partial class TensorExpression
    {
        private static TensorExpression Op_Sum(TensorExpression l) => null;
        private static TensorExpression Op_Mean(TensorExpression l) => null;
    }
}
