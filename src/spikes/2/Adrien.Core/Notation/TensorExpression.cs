using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class TensorExpression<T> : Term where T : unmanaged
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
        public static TensorExpression<T> operator - (TensorExpression<T> left)
        {
            return new TensorExpression<T>(Expression.Negate(left));
        }

        public static TensorExpression<T> operator + (TensorExpression<T> left, TensorExpression<T> right)
        {
            return new TensorExpression<T>(Expression.Add(left, right));
        }

        public static TensorExpression<T> operator - (TensorExpression<T> left, TensorExpression<T> right)
        {
            return new TensorExpression<T>(Expression.Subtract(left, right));
        }

        public static TensorExpression<T> operator * (TensorExpression<T> left, TensorExpression<T> right)
        {
            return new TensorExpression<T>(Expression.Multiply(left, right));
        }

        public static TensorExpression<T> operator / (TensorExpression<T> left, TensorExpression<T> right)
        {
            return new TensorExpression<T>(Expression.Divide(left, right));
        }
        #endregion
    }
}
