using System;
using System.Collections.Generic;

namespace Adrien.Ast
{
    /// <summary>
    /// A sequence of statements, which represents the symbolic
    /// calculations that defines symbols.
    /// </summary>
    public class Tile
    {
        public string Name { get; }

        public IReadOnlyList<Statement> Statements { get; }

        public Tile(string name, IReadOnlyList<Statement> statements)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
            Statements = statements ?? throw new ArgumentNullException(nameof(statements));
        }
    }
}