using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class TensorExpressionException : Exception
    {
        public TensorExpression TensorExpression { get; protected set; }

        public TensorExpressionException(TensorExpression expr, string message) : base(message)
        {
            TensorExpression = expr;
        }
    }
}
