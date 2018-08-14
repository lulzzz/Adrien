using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Adrien.Trees;
using Adrien.Expressions;

namespace Adrien.Notation
{
    public class TensorIndexExpression : TensorExpression
    {
        public NewArrayExpression Bounds { get; protected set; }

      
        public TensorIndexExpression(IndexExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<Tensor>();
            Bounds = bounds;
        }

        public TensorIndexExpression(MethodCallExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorIndexExpression>();
            Bounds = bounds;
        }

        public TensorIndexExpression(UnaryExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorExpression>();
            Bounds = bounds;
        }

        public TensorIndexExpression(BinaryExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorExpression>();
            Bounds = bounds;
        }
        
        public TensorIndexExpression(TensorIndexExpression c, NewArrayExpression bounds = null) : base(c.LinqExpression)
        {
            this.Bounds = bounds;
        }
        

        public TensorIndexExpression this[Index d]
        {
            get => new TensorIndexExpression(this, Expression.NewArrayBounds(typeof(TensorContraction), 
                Expression.Convert(d.LinqExpression, typeof(Int32))));
        }
        
        public static TensorIndexExpression operator * (TensorIndexExpression left, TensorIndexExpression right) =>
            new TensorIndexExpression(Expression.Multiply(left, right, GetDummyBinaryMethodInfo(right, right)));
    }
}
