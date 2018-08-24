using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    public enum IndexExpressionArityKind
    {
        Constant,
        Term,
        Lookup,
        Binary
    }

    public enum BinaryIndexExpressionKind
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    /// <summary>
    /// An expression that logically represents the calculation
    /// associated to index that parametrize the access to a symbol. 
    /// </summary>
    public class IndexExpression
    {
        public IndexExpressionArityKind ArityKind { get; set; }

        public BinaryExpressionKind BinaryKind { get; set; }

        public Index Term { get; set; }

        public IndexExpression(Index term)
        {
            ArityKind = IndexExpressionArityKind.Term;
            Term = term;
        }

        public IReadOnlyList<Index> Indices
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
