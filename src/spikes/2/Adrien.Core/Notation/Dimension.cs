﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Adrien.Notation
{
    public class Dimension : Term, IChildTerm, IAlgebra<Dimension, Dimension>
    {
        public Tensor Tensor { get; internal set; }

        public ITerm Parent => Tensor;

        public DimensionType DimensionType { get; protected set; }

        public int Order { get; protected set; }

        public int Length { get; protected set; }

        public int Stride { get; protected set; }

        protected Expression DimensionExpression { get; set; }

        internal override Name DefaultNameBase { get; } = "N0";

        internal override Expression LinqExpression => Expression.Parameter(typeof(Dimension), Id);

        internal override Type ExpressionType { get; } = typeof(Dimension);

        protected Dimension(Tensor t, int order, string label) : base(label)
        {
            this.Tensor = t;
            this.Order = order;
        }

        internal Dimension(Tensor t, int order, int length) : this(t, order, t.Label + order.ToString())
        {
            this.Length = length;
            this.Stride = t.Strides[order];
            this.DimensionExpression = Expression.Constant(Length);
            this.DimensionType = DimensionType.Constant;
        }

        internal Dimension(Expression dimExpression) : this(null, -1, 
            "dim_" + GetNameFromLinqExpression(dimExpression))
        {
            this.DimensionExpression = dimExpression;
            this.DimensionType = DimensionType.Expression;
        }

        internal Dimension(Int32 i) : this(Expression.Constant(i)) {}

        public static Dimension operator -(Dimension left) => left.Negate();

        public static Dimension operator +(Dimension left, Dimension right) => left.Add(right);

        public static Dimension operator -(Dimension left, Dimension right) => left.Subtract(right);

        public static Dimension operator *(Dimension left, Dimension right) => left.Multiply(right);

        public static Dimension operator /(Dimension left, Dimension right) => left.Divide(right);

        public static implicit operator Dimension(int d) => new Dimension(null, -1, d);

        public static explicit operator Scalar(Dimension d) => d.DimensionType == DimensionType.Constant ?
            new Scalar(d.Label) : throw new ArgumentException("The specified dimension is not a dimension constant");

        public Dimension Negate() => new Dimension(Expression.Negate(DimensionExpression, 
            GetDummyUnaryMethodInfo<Dimension, Dimension>(this)));

        public Dimension Add(Dimension right) => new Dimension(Expression.Add(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Subtract(Dimension right) => new Dimension(Expression.Subtract(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Multiply(Dimension right) => new Dimension(Expression.Multiply(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));

        public Dimension Divide(Dimension right) => new Dimension(Expression.Divide(this, 
            right.DimensionExpression, GetDummyBinaryMethodInfo<Dimension, Dimension>(this, right)));


        private static Dimension DummyUnary(Dimension l) => null;
        private static Dimension DummyBinary(Dimension l, Dimension r) => null;

    }

}