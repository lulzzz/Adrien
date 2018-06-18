using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class TensorExpression : Term, IAlgebra<TensorExpression>
    {
        internal override Expression LinqExpression { get; }
        
        internal override Name DefaultNameBase => "A";


        public TensorExpression(Expression e)
        {
            LinqExpression = e;
        }


        public static TensorExpression operator - (TensorExpression left) => left.Negate();

        public static TensorExpression operator + (TensorExpression left, TensorExpression right) => left.Add(right);


        public static TensorExpression operator - (TensorExpression left, TensorExpression right) => left.Subtract(right);


        public static TensorExpression operator * (TensorExpression left, TensorExpression right) => left.Multiply(right);


        public static TensorExpression operator / (TensorExpression left, TensorExpression right) => left.Divide(right);
        

        public TensorExpression Negate() => new TensorExpression(Expression.Negate(this));
        
        public TensorExpression Add(TensorExpression right) => new TensorExpression(Expression.Add(this, right));

        public TensorExpression Subtract(TensorExpression right) => new TensorExpression(Expression.Subtract(this, right));

        public TensorExpression Multiply(TensorExpression right) => new TensorExpression(Expression.Multiply(this, right));

        public TensorExpression Divide(TensorExpression right) => new TensorExpression(Expression.Divide(this, right));
    }
}