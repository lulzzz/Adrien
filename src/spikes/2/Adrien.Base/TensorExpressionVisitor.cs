using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Adrien;

namespace Adrien.Generators.Tile
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public TensorExpressionVisitor(Expression expr) : base()
        {
            Expression = expr;

        }

        #region Properties
        public Expression Expression { get; protected set; }
        #endregion
    }
}
