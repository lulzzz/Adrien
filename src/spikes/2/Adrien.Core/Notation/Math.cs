﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    public static class Math
    {
        public static TensorExpression SigmaSum(TensorExpression l) =>
            new TensorExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_SigmaSum", 1),
                Expression.Convert(l.LinqExpression, typeof(TensorExpression))));

        public static TensorExpression Square(TensorExpression l) =>
            new TensorExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Square", 1),
                Expression.Convert(l.LinqExpression, typeof(TensorExpression))));

        public static TensorExpression Sqrt(TensorExpression l) =>
            new TensorExpression(Expression.Call(TensorExpression.GetOpMethodInfo<TensorExpression>("Op_Sqrt", 1),
         Expression.Convert(l.LinqExpression, typeof(TensorExpression))));
    }

    public partial class TensorExpression
    {
        private static TensorExpression Op_SigmaSum(TensorExpression l) => null;
        private static TensorExpression Op_Square(TensorExpression l) => null;
        private static TensorExpression Op_Sqrt(TensorExpression l) => null;
    }
}