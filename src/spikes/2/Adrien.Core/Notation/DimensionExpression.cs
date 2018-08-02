using System;
using System.Collections.Generic;
using System.Text;

using Sawmill;
using Sawmill.Expressions;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Expressions;
using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Notation
{
    public class DimensionExpression : Term, IAlgebra<DimensionExpression, DimensionExpression>
    {
        internal override Expression LinqExpression { get; }

        internal override Name DefaultNameBase => "dim_expr0";

        public List<Index> Indices => LinqExpression.GetConstants<Index>();
        
        public DimensionExpression(Expression e)
        {
            LinqExpression = e;
            Name = GetNameFromLinqExpression(LinqExpression);
        }


        public static implicit operator DimensionExpression (Index i) => new DimensionExpression(i.LinqExpression);

        public static implicit operator Index(DimensionExpression expr) => new Index(expr);

        public static implicit operator DimensionExpression(Int32 i) => new DimensionExpression(Expression.Constant(i));

        public static implicit operator Int32(DimensionExpression t) => Int32.MinValue;

        public static DimensionExpression operator - (DimensionExpression left) => left.Negate();

        public static DimensionExpression operator + (DimensionExpression left, DimensionExpression right) 
            => left.Add(right);

        public static DimensionExpression operator - (DimensionExpression left, DimensionExpression right) 
            => left.Subtract(right);

        public static DimensionExpression operator * (DimensionExpression left, DimensionExpression right) 
            => left.Multiply(right);

        public static DimensionExpression operator / (DimensionExpression left, DimensionExpression right) 
            => left.Divide(right);


        public DimensionExpression Negate() => new DimensionExpression(Expression.Negate(this));

        public DimensionExpression Add(DimensionExpression right) 
            => new DimensionExpression(Expression.Add(this, right));

        public DimensionExpression Subtract(DimensionExpression right) 
            => new DimensionExpression(Expression.Subtract(this, right));

        public DimensionExpression Multiply(DimensionExpression right) 
            => new DimensionExpression(Expression.Multiply(this, right));

        public DimensionExpression Divide(DimensionExpression right) 
            => new DimensionExpression(Expression.Divide(this, right));
    }
}