using System;
using System.Collections.Generic;
using System.Text;

using Sawmill;
using Sawmill.Expressions;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Notation
{
    public class TensorIndexExpression : Term, IAlgebra<TensorIndexExpression, TensorIndexExpression>
    {
        internal override Expression LinqExpression { get; }

        internal override Name DefaultNameBase => "index_expr0";

        //public List<Index> Indices => LinqExpression.GetConstants<Index>();
        
        
        public TensorIndexExpression(Expression e)
        {
            LinqExpression = e;
            Name = GetNameFromLinqExpression(LinqExpression);
        }


        public static implicit operator TensorIndexExpression (Index i) => 
            new TensorIndexExpression(i.LinqExpression);

        public static implicit operator Index(TensorIndexExpression expr) => new Index(expr);

        public static implicit operator TensorIndexExpression(Int32 i) 
            => new TensorIndexExpression(Expression.Constant(i));

        public static implicit operator Int32(TensorIndexExpression t) => Int32.MinValue;

        public static TensorIndexExpression operator - (TensorIndexExpression left) => left.Negate();

        public static TensorIndexExpression operator + (TensorIndexExpression left, TensorIndexExpression right) 
            => left.Add(right);

        public static TensorIndexExpression operator - (TensorIndexExpression left, TensorIndexExpression right) 
            => left.Subtract(right);

        public static TensorIndexExpression operator * (TensorIndexExpression left, TensorIndexExpression right) 
            => left.Multiply(right);

        public static TensorIndexExpression operator / (TensorIndexExpression left, TensorIndexExpression right) 
            => left.Divide(right);


        public TensorIndexExpression Negate() => new TensorIndexExpression(Expression.Negate(this));

        public TensorIndexExpression Add(TensorIndexExpression right) 
            => new TensorIndexExpression(Expression.Add(this, right));

        public TensorIndexExpression Subtract(TensorIndexExpression right) 
            => new TensorIndexExpression(Expression.Subtract(this, right));

        public TensorIndexExpression Multiply(TensorIndexExpression right) 
            => new TensorIndexExpression(Expression.Multiply(this, right));

        public TensorIndexExpression Divide(TensorIndexExpression right) 
            => new TensorIndexExpression(Expression.Divide(this, right));
    }
}