using System;
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
        public Symbol Symbol { get; set; }

        public IReadOnlyList<Index> Indices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<IndexExpression> Expressions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Element(Symbol symbol, params IndexExpression[] expressions)
        {
            throw new NotImplementedException();
        }
    }
}
