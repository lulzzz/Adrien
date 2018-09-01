using System.Collections.Generic;

namespace Adrien.Ast
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
        public Symbol Symbol { get; }

        public IReadOnlyList<IndexExpression> Expressions { get; }

        public Element(Symbol symbol, IReadOnlyList<IndexExpression> expressions)
        {
            Symbol = symbol;
            Expressions = expressions;
        }
    }
}