using System;
using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentIndexExpression : IndexExpression
    {
        public FluentIndexExpression(FluentIndex term) : base(term)
        {
        }

        public static FluentIndexExpression operator +(FluentIndexExpression expr1, FluentIndexExpression expr2)
        {
            throw new NotImplementedException();
        }
    }
}
