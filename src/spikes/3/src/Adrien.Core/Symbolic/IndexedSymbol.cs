using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    /// <summary>
    /// A symbol that is fully parametrized by its complete
    /// Einstein-like notation.
    /// </summary>
    public class IndexedSymbol
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

        public IndexedSymbol(Symbol symbol, params IndexExpression[] expressions)
        {
            throw new NotImplementedException();
        }
    }
}
