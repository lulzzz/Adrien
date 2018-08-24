using System;
using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentIndexedSymbol : IndexedSymbol
    {
        public FluentIndexedSymbol(FluentSymbol symbol, params FluentIndexExpression[] expr) : base(symbol, expr)
        {
        }

        public static implicit operator FluentExpression(FluentIndexedSymbol symbol)
        {
            return new FluentExpression(symbol);
        }
    }
}
