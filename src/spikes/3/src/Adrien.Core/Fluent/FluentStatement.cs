using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentStatement : Statement
    {
        public FluentStatement(IndexedSymbol left, StatementKind kind, Expression expression) : base(left, kind, expression)
        {
        }
    }
}
