using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorIndexExpression Sum(TensorIndexExpression l) =>
            new TensorIndexExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorIndexExpression>("Op_Sum", 1), 
                Expression.Convert(l, typeof(TensorIndexExpression))));

        public static TensorExpression Mean(TensorIndexExpression l)
        {
            var tensor = (Tensor) l;
            var indices = l.IndexParameters;
            TensorExpression mulExpr = indices.Count > 1 ?
                tensor.Dim[indices[0]] * tensor.Dim[indices[1]] : tensor.Dim[indices[0]];
            for (int i = 2; i < indices.Count; i++)
            {
                mulExpr = mulExpr * tensor.Dim[indices[i]];
            }
            return Sum(l) / mulExpr;
        }       
    }

    public partial class TensorExpression
    {
        private static TensorIndexExpression Op_Sum(TensorIndexExpression l) => null;
        private static TensorIndexExpression Op_Mean(TensorIndexExpression l) => null;
    }
}
