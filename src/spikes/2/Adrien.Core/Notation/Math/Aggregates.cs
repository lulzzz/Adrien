using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorContraction Sum(TensorIndexExpression l) => 
            new TensorContraction(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sum", 1),
                Expression.Convert(l.LinqExpression, typeof(TensorExpression))), l.Bounds);

        public static TensorContraction Sum(TensorExpression l)
        {
            Tensor t = l.Tensors.Single();
            Array o = Array.CreateInstance(typeof(Tensor), t.Dimensions);
            Expression[] p = new IndexSet(t).Select(i => Expression.Parameter(typeof(Int32), i.Id)).ToArray();
            return new TensorContraction(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sum", 1),
                Expression.Convert(Expression.ArrayAccess(Expression.Constant(o), p), typeof(TensorExpression))));
        }

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
            return Sum(l) / mulExpr;
        }

        public static TensorExpression Mean(TensorExpression l)
        {
            var tensor = l.Tensors.Single();
            TensorExpression mulExpr = tensor.Axes.Length > 1 ?
                tensor.Axes[0] * tensor.Axes[1] : tensor.Axes[0];
            for (int i = 2; i < tensor.Axes.Length; i++)
            {
                mulExpr = mulExpr * tensor.Axes[i];
            }
            return Sum(l) / mulExpr;
        }
    }

    public partial class TensorExpression
    {
        private static TensorExpression Op_Sum(TensorExpression l) => null;
        private static TensorExpression Op_Mean(TensorExpression l) => null;
    }
}
