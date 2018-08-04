using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Adrien.Expressions;

namespace Adrien.Notation
{
    public class TensorContraction : TensorIndexExpression, IContractionOp
    {
        public TensorContraction(IndexExpression expr, NewArrayExpression bounds = null) : base(expr, bounds) { }

        public TensorContraction(MethodCallExpression expr, NewArrayExpression bounds = null) : base(expr, bounds) { }

        public TensorContraction(UnaryExpression expr, NewArrayExpression bounds = null) : base(expr, bounds) { }

        public TensorContraction(BinaryExpression expr, NewArrayExpression bounds = null) : base(expr, bounds) { }

        public TensorContraction(TensorIndexExpression c, NewArrayExpression bounds = null) : base(c, bounds) {}

        public static TensorContraction operator * (TensorContraction left, TensorContraction right) =>
            new TensorContraction(Expression.Multiply(left, right, GetDummyBinaryMethodInfo(right, right)));
    }
}
