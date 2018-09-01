using System.Collections.Generic;

namespace Adrien.Ast
{
    /// <summary>
    /// A sequence of statements, which represents the symbolic
    /// calculations that defines symbols.
    /// </summary>
    public class Tile
    {
        private readonly List<Symbol> _inputs;

        private readonly List<Symbol> _outputs;

        private readonly List<Statement> _statements;

        private readonly List<Beam<Symbol>> _beams;

        public string Name { get; }

        public IReadOnlyList<Symbol> Inputs => _inputs;

        public IReadOnlyList<Symbol> Outputs => _outputs;

        public IReadOnlyList<Statement> Statements => _statements;

        public Tile(string name)
        {
            Name = name;
            _inputs = new List<Symbol>();
            _outputs = new List<Symbol>();
            _statements = new List<Statement>();
            _beams = new List<Beam<Symbol>>();
        }

        public void AddInput(Symbol input)
        {
            _inputs.Add(input);
        }

        public void AddOutput(Symbol output)
        {
            _outputs.Add(output);
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