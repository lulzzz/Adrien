using System;
using System.Collections.Generic;

using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    public class TensorContraction : TensorExpression, IContractionOp
    {
        public TensorContraction(Expression expr) : base(expr) {}

        public TensorContraction(BinaryExpression expr) : base(expr) { }

        public static TensorContraction operator * (TensorContraction left, TensorContraction right) =>
            new TensorContraction(Expression.Multiply(left, right, GetDummyBinaryMethodInfo(right, right)));
    }
}
