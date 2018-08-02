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
        public TensorContraction(IndexExpression expr) : base(expr) { }

        public TensorContraction(MethodCallExpression expr) : base(expr) { }

        public TensorContraction(UnaryExpression expr) : base(expr) { }

        public TensorContraction(BinaryExpression expr) : base(expr) { }

       
        public static TensorContraction operator * (TensorContraction left, TensorContraction right) =>
            new TensorContraction(Expression.Multiply(left, right, GetDummyBinaryMethodInfo(right, right)));
    }
}
