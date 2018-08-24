using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentIndex : Index
    {
        public static implicit operator FluentIndexExpression(FluentIndex index)
        {
            var term = new FluentIndexExpression(index);

            return term;
        }
    }
}
