using System;
using System.Collections.Generic;
using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class TileExtensions
    {
        public static bool StructuralEquals(this Tile tile, Tile other)
        {
            if (tile == null && other == null)
                return true;

            if (tile.Name != other.Name)
                return false;

            if (tile.Statements.Count != other.Statements.Count)
                return false;

            foreach(var (a,b) in tile.Statements.Zip(other.Statements, (a,b) => (a,b)))
                if (!a.StructuralEquals(b))
                    return false;

            return true;
        }

        public static IReadOnlyList<Symbol> Symbols(this Tile tile)
        {
            var symbols = new HashSet<Symbol>();

            foreach (var statement in tile.Statements)
            {
                symbols.Add(statement.Left.Symbol);
                symbols.AddRange(statement.Right.Symbols());
            }

            return symbols.OrderBy(s => s.Position).ToList();
        }

        public static IReadOnlyList<Symbol> Inputs(this Tile tile)
        {
            var inputs = new HashSet<Symbol>();

            foreach(var statement in tile.Statements)
                inputs.AddRange(statement.Right.Symbols());

            foreach (var output in tile.Outputs())
                inputs.Remove(output);

            return inputs.OrderBy(s => s.Position).ToList();
        }

        public static IReadOnlyList<Symbol> Outputs(this Tile tile)
        {
            var outputs = new HashSet<Symbol>();
            outputs.AddRange(tile.Statements.Select(s => s.Left.Symbol));

            return outputs.OrderBy(s => s.Position).ToList();
        }
    }
}
