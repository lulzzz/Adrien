using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorContraction SigmaSum(TensorIndexExpression l) =>
         new TensorContraction(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sum", 1),
             Expression.Convert(l.LinqExpression, typeof(TensorExpression))), l.Bounds);

        public static TensorExpression Mean(TensorIndexExpression l)
        {
            var tensor = l.Tensors.Single();
            var indices = l.IndexParameters;
            TensorExpression mulExpr = indices.Count > 1 ?
                tensor.Dim[indices[0]] * tensor.Dim[indices[1]] : tensor.Dim[indices[0]];
            for (int i = 2; i < indices.Count; i++)
            {
                mulExpr = mulExpr * tensor.Dim[indices[i]];
            }
            return SigmaSum(l) / mulExpr;
        }
    }

    public partial class TensorExpression
    {
        private static TensorExpression Op_Sum(TensorExpression l) => null;
        private static TensorExpression Op_Mean(TensorExpression l) => null;
    }
}
