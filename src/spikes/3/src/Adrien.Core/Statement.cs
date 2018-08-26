using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    public enum StatementKind
    {
        ElementWise,
        Sum,
        Max
    }

    /// <summary>
    /// One logical calculation step within a tile.
    /// </summary>
    public class Statement
    {
        public bool InitializeAtZero { get; set; }

        public Element Left { get; set; }

        public StatementKind Kind { get; set; }

        public ElementExpression Expression { get; set; }

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

        public Statement(Element left, StatementKind kind, ElementExpression expression)
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
