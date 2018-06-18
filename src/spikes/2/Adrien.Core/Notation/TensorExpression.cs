using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class TensorExpression : Term
    {
        internal override Expression LinqExpression { get; }
        
        internal override Name DefaultNameBase => "A";


        public TensorExpression(Expression e)
        {
            LinqExpression = e;
        }
        

        public static TensorExpression operator - (TensorExpression left)
        {
            return new TensorExpression(Expression.Negate(left));
        }

        public static TensorExpression operator + (TensorExpression left, TensorExpression right)
        {
            return new TensorExpression(Expression.Add(left, right));
        }

        public static TensorExpression operator - (TensorExpression left, TensorExpression right)
        {
            return new TensorExpression(Expression.Subtract(left, right));
        }

        public static TensorExpression operator * (TensorExpression left, TensorExpression right)
        {
            return new TensorExpression(Expression.Multiply(left, right));
        }

        public static TensorExpression operator / (TensorExpression left, TensorExpression right)
        {
            return new TensorExpression(Expression.Divide(left, right));
        }
        
    }
}
