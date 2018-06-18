using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Adrien;

namespace Adrien.Generators.Tile
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public Expression Expression { get; protected set; }

        public TensorExpressionVisitor(Expression expr) : base()
        {
            Expression = expr;

        }

        
        
        
    }
}
