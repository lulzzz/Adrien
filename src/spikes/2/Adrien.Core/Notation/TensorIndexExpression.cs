using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Adrien.Trees;
using Adrien.Expressions;

namespace Adrien.Notation
{
    public class TensorIndexExpression : TensorExpression, IAlgebra<TensorIndexExpression, TensorIndexExpression>
    {
        public NewArrayExpression Bounds { get; protected set; }

      
        internal TensorIndexExpression(IndexExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<Tensor>();
            if (!(expr.Object is ConstantExpression))
            {
                throw new ArgumentException("This Linq expression cannot be used as a tensor index expression.");
            }    
            Bounds = bounds;
        }

        internal TensorIndexExpression(MethodCallExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorIndexExpression>();
            Bounds = bounds;
        }

        internal TensorIndexExpression(UnaryExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorExpression>();
            expr.Operand.ThrowIfNotType<TensorIndexExpression>();
            Bounds = bounds;
        }

        internal TensorIndexExpression(BinaryExpression expr, NewArrayExpression bounds = null) : base(expr)
        {
            expr.ThrowIfNotType<TensorIndexExpression>();
            Bounds = bounds;
        }

        internal TensorIndexExpression(TensorIndexExpression c, NewArrayExpression bounds = null) : base(c.LinqExpression)
        {
            this.Bounds = bounds;
        }

        public TensorIndexExpression this[Dimension n]
        {
            get => new TensorIndexExpression(this, Expression.NewArrayBounds(typeof(TensorIndexExpression),
                Expression.Convert(n.LinqExpression, typeof(Int32)), Expression.Convert(n.LinqExpression, typeof(Int32))));
        }

        public TensorIndexExpression this[Index l, Index u]
        {
            get => new TensorIndexExpression(this, Expression.NewArrayBounds(typeof(TensorIndexExpression), 
                Expression.Convert(l.LinqExpression, typeof(Int32)), Expression.Convert(u.LinqExpression, typeof(Int32))));
        }

        public static TensorIndexExpression operator +(TensorIndexExpression left, TensorIndexExpression right) =>
           new TensorIndexExpression(Expression.Add(left, right,
               GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator -(TensorIndexExpression left, TensorIndexExpression right) =>
           new TensorIndexExpression(Expression.Subtract(left, right,
               GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator *(TensorIndexExpression left, TensorIndexExpression right) =>
            new TensorIndexExpression(Expression.Multiply(left, right, 
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator *(TensorIndexExpression left, TensorExpression right) =>
            new TensorIndexExpression(Expression.Multiply(left, right,
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorExpression>(left, right)));


        public static TensorIndexExpression operator /(TensorIndexExpression left, TensorIndexExpression right) =>
            new TensorIndexExpression(Expression.Divide(left, right,
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator /(TensorIndexExpression left, TensorExpression right) =>
            new TensorIndexExpression(Expression.Divide(left, right,
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorExpression>(right, right)));

        public new TensorIndexExpression Negate() => new TensorIndexExpression(Expression.Negate(this, 
            GetDummyUnaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(this)));

        public TensorIndexExpression Add(TensorIndexExpression right) => new TensorIndexExpression(Expression.Add(this, right,
            GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(this, right)));

        public TensorIndexExpression Subtract(TensorIndexExpression right) => new TensorIndexExpression(Expression.Subtract(this,
            right, GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(this, right)));

        public TensorIndexExpression Multiply(TensorIndexExpression right) => new TensorIndexExpression(Expression.Multiply(this,
            right, GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(this, right)));

        public TensorIndexExpression Divide(TensorIndexExpression right) => new TensorIndexExpression(Expression.Divide(this, right,
            GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(this, right)));

        private static TensorIndexExpression DummyUnary(Tensor l) => null;
        private static TensorIndexExpression DummyBinary(Tensor l, Tensor r) => null;
        private static TensorIndexExpression DummyBinary(TensorIndexExpression l, Tensor r) => null;
        private static TensorIndexExpression DummyBinary(TensorIndexExpression l, TensorIndexExpression r) => null;
        private static TensorIndexExpression DummyBinary(TensorIndexExpression l, TensorExpression r) => null; 
    }
}
