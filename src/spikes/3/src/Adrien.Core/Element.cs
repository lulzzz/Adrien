using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// An element that is fully parametrized symbol by its complete
    /// Einstein-like notation.
    /// </summary>
    /// <remarks>
    ///In 'A[i,j] = B[i,k] * C[k, j]'
    /// 'Á' is a symbol while 'A[i,j]' is an element.
    /// </remarks>
    public class Element
    {
        private readonly IndexExpression[] _expressions;

        public Symbol Symbol { get; }

        public IReadOnlyList<IndexExpression> Expressions => _expressions;

        public Element(Symbol symbol, params IndexExpression[] expressions)
        {
            Symbol = symbol;
            _expressions = expressions;
        }
    }
}
