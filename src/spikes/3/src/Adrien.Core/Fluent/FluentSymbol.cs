using System;
using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentSymbol : Symbol
    {
        public FluentSymbol(string name) : base(name)
        {
        }

        public FluentExpression this[FluentIndexExpression expr1]
        {
            get
            {
                return new FluentExpression(new FluentIndexedSymbol(this, expr1));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public FluentExpression this[FluentIndexExpression expr1, FluentIndexExpression expr2]
        {
            get
            {
                return new FluentExpression(new FluentIndexedSymbol(this, expr1));
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
