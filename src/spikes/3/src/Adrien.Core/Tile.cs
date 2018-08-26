using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// A sequence of statements, which represents the symbolic
    /// calculations that defines symbols.
    /// </summary>
    public class Tile
    {
        public IReadOnlyList<Symbol> Inputs
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Symbol> Outputs
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

        public void Add(Statement statement)
        {
            throw new NotImplementedException();
        }

        public void Add(Variable v, Func<Symbol,Beam> getBeam)
        {
            throw new NotImplementedException();
        }

        public void Add(Variable v1, Variable v2, Func<Symbol, Symbol, Beam> getBeam)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Beam> GetBeams(IReadOnlyDictionary<Variable, Symbol> map)
        {
            throw new NotImplementedException();
        }
    }
}
