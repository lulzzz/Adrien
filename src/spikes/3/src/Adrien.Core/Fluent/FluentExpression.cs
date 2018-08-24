using System;
using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentExpression : Expression
    {
        public FluentExpression(FluentIndexedSymbol indexed) : base(indexed)
        {
        }

        public static implicit operator FluentStatement(FluentExpression expr)
        {
            throw new NotImplementedException();
        }

        public static FluentExpression operator +(FluentExpression expr1, FluentExpression expr2)
        {
            throw new NotImplementedException();
        }

        public static FluentExpression operator *(FluentExpression expr1, FluentExpression expr2)
        {
            throw new NotImplementedException();
        }
    }
}
