using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class TensorExpression : Term
    {
        #region Constructors
        public TensorExpression(Expression e)
        {
            LinqExpression = e;
        }
        #endregion

        #region Overriden members
        internal override Name DefaultNameBase => "A";
        #endregion

        #region Properties
        internal override Expression LinqExpression { get; }
        #endregion

        #region Operators
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
        #endregion
    }
}
