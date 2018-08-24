using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    /// <summary>
    /// A sequence of statements, which represents the symbolic
    /// calculations that defines symbols.
    /// </summary>
    public class Flow
    {
        public void Add(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public void Add(Statement statement)
        {
            throw new NotImplementedException();
        }

        public void Add(Beam beam)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Symbol> Symbols
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Statement> Statements
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Beam> Beams
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
