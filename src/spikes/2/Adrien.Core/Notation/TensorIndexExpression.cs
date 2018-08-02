using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Adrien.Expressions;

namespace Adrien.Notation
{
    public class TensorIndexExpression : TensorExpression
    {
        public NewArrayExpression Bounds { get; protected set; }


        public TensorIndexExpression(IndexExpression expr) : base(expr) {}

        public TensorIndexExpression(MethodCallExpression expr) : base(expr) { }

        public TensorIndexExpression(UnaryExpression expr) : base(expr) { }

        public TensorIndexExpression(BinaryExpression expr) : base(expr) { }
        
        public TensorIndexExpression(TensorIndexExpression c, NewArrayExpression bounds) : base(c.LinqExpression)
        {
            this.Bounds = bounds;
        }
        
        public TensorIndexExpression this[DimensionExpression d]
        {
            get => new TensorIndexExpression(this, Expression.NewArrayBounds(typeof(TensorContraction), 
                Expression.Convert(d.LinqExpression, typeof(Int32))));
        }
        
        public static TensorIndexExpression operator * (TensorIndexExpression left, TensorIndexExpression right) =>
            new TensorIndexExpression(Expression.Multiply(left, right, GetDummyBinaryMethodInfo(right, right)));
    }
}
