using System;

namespace Adrien.Fluent
{
    public class FElementExpression
    {
        public FElementExpression(FElement indexed)
        {
        }

        public static implicit operator FStatement(FElementExpression expr)
        {
            throw new NotImplementedException();
        }

        public static FElementExpression operator +(FElementExpression expr1, FElementExpression expr2)
        {
            throw new NotImplementedException();
        }

        public static FElementExpression operator *(FElementExpression expr1, FElementExpression expr2)
        {
            throw new NotImplementedException();
        }
    }
}
