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
        private readonly List<Statement> _statements;

        private readonly List<Beam<Symbol>> _beams;

        public string Name { get; }

        public IReadOnlyList<Statement> Statements
            => _statements;

        public Tile(string name)
        {
            Name = name;
            _statements = new List<Statement>();
            _beams = new List<Beam<Symbol>>();
        }

        public void Add(Statement statement)
        {
            _statements.Add(statement);
        }

        public void Add(Beam<Symbol> beam)
        {
            _beams.Add(beam);
        }
    }
}
