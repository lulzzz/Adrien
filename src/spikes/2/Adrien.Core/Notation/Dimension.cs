using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Adrien.Notation
{
    public class Dimension : Term, IChildTerm, IAlgebra<Dimension, Dimension>
    {
        public Tensor Tensor { get; protected set; }

        public ITerm Parent => Tensor;

        public DimensionType DimensionType { get; protected set; }

        public int Order { get; protected set; }

        public int Length { get; protected set; }

        public int Stride { get; protected set; }

        protected Expression DimensionExpression { get; set; }

        internal override Name DefaultNameBase { get; } = "N0";

        internal override Expression LinqExpression => Expression.NewArrayBounds(typeof(TensorIndexExpression),
                Expression.Convert(DimensionExpression, typeof(int)));

        internal override Type ExpressionType { get; } = typeof(Dimension);

        protected Dimension(Tensor t, int order, string label) : base(label)
        {
            this.Tensor = t;
            this.Order = order;
            this.DimensionExpression = Expression.Parameter(typeof(int), Id);
        }

        internal Dimension(Tensor t, int order, int length) : this(t, order, t.Label + order.ToString())
        {
            this.Length = length;
            this.Stride = t.Strides[order];
            this.DimensionType = DimensionType.Constant;
        }

        internal Dimension(Tensor t, int order, Expression dimExpression) : this(t, order, t.Label + order.ToString())
        {
            this.DimensionExpression = dimExpression;
            this.DimensionType = DimensionType.Expression;
        }

        internal Dimension(Dimension dim, Expression dimExpression) : 
            this(dim.Tensor, dim.Order, "dim_" + GetNameFromLinqExpression(dimExpression)) {}


        public static Dimension operator -(Dimension left) => left.Negate();

        public static Dimension operator +(Dimension left, Dimension right) => left.Add(right);

        public static Dimension operator -(Dimension left, Dimension right) => left.Subtract(right);

        public static Dimension operator *(Dimension left, Dimension right) => left.Multiply(right);

        public static Dimension operator /(Dimension left, Dimension right) => left.Divide(right);


        public Dimension Negate() => new Dimension(this, Expression.Negate(DimensionExpression, 
            GetDummyUnaryMethodInfo<Dimension, Dimension>(this)));

        public Dimension Add(Dimension right) => new Dimension(this, Expression.Add(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Subtract(Dimension right) => new Dimension(this, Expression.Subtract(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Multiply(Dimension right) => new Dimension(this, Expression.Multiply(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Divide(Dimension right) => new Dimension(this, Expression.Divide(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        private static Dimension DummyUnary(Dimension l) => null;
        private static Dimension DummyBinary(Dimension l, Dimension r) => null;

    }

}