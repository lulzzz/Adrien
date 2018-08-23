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
        public Dimension[] Shape { get; protected set; }

      
        internal TensorIndexExpression(IndexExpression expr, params Dimension[] shape) : base(expr)
        {
            expr.ThrowIfNotType<Tensor>();
            if (!(expr.Object is ConstantExpression))
            {
                throw new ArgumentException("This Linq expression cannot be used as a tensor index expression.");
            }    
            Shape = shape;
        }

        internal TensorIndexExpression(MethodCallExpression expr, params Dimension[] shape) : base(expr)
        {
            expr.ThrowIfNotType<TensorIndexExpression>();
            Shape = shape;
        }

        internal TensorIndexExpression(UnaryExpression expr, params Dimension[] shape) : base(expr)
        {
            expr.ThrowIfNotType<TensorExpression>();
            expr.Operand.ThrowIfNotType<TensorIndexExpression>();
            Shape = shape;
        }

        internal TensorIndexExpression(BinaryExpression expr, params Dimension[] shape ) : base(expr)
        {
            expr.ThrowIfNotType<TensorIndexExpression>();
            Shape = shape;
        }

        internal TensorIndexExpression(TensorIndexExpression c, params Dimension[] shape ) : base(c.LinqExpression)
        {
            this.Shape = shape;
        }

        public TensorIndexExpression this[Dimension n] => new TensorIndexExpression(this, n);
  
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
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator *(TensorExpression left, TensorIndexExpression right) =>
           new TensorIndexExpression(Expression.Multiply(right, left,
               GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(right, left)));

        public static TensorIndexExpression operator /(TensorIndexExpression left, TensorIndexExpression right) =>
            new TensorIndexExpression(Expression.Divide(left, right,
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));

        public static TensorIndexExpression operator /(TensorIndexExpression left, TensorExpression right) =>
            new TensorIndexExpression(Expression.Divide(left, right,
                GetDummyBinaryMethodInfo<TensorIndexExpression, TensorIndexExpression>(left, right)));


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
        private static TensorIndexExpression DummyBinary(TensorIndexExpression l, Scalar r) => null;
        private static TensorIndexExpression DummyBinary(Scalar l, TensorIndexExpression r) => null;
    }
}
