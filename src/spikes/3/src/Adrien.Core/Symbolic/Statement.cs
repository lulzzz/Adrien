using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    public enum StatementKind
    {
        ElementWise,
        Sum,
        Max
    }

    /// <summary>
    /// One logical calculation step within a flow.
    /// </summary>
    public class Statement
    {
        public bool InitializeAtZero { get; set; }

        public IndexedSymbol Left { get; set; }

        public StatementKind Kind { get; set; }

        public Expression Expression { get; set; }

        public IReadOnlyList<Index> Indices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Symbol> Symbols
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Statement(IndexedSymbol left, StatementKind kind, Expression expression)
        {
            Left = left;
            Kind = kind;
            Expression = expression;
        }

        public void Add(Index index)
        {
            throw new NotImplementedException();
        }
    }
}
