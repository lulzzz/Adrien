using System;

namespace Adrien.Fluent
{
    public class FElement
    {
        public FElement(FSymbol symbol, params FIndexExpression[] expr) 
        {
            throw new NotImplementedException();
        }

        public static implicit operator FElementExpression(FElement symbol)
        {
            return new FElementExpression(symbol);
        }
    }
}
