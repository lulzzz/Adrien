using System.Linq;

namespace Adrien.Ast.Extensions
{
    public static class TileExtensions
    {
        public static bool StructuralEquals(this Tile tile, Tile other)
        {
            if (tile.Name != other.Name)
                return false;

            if (tile.Statements.Count != other.Statements.Count)
                return false;

            foreach(var (a,b) in tile.Statements.Zip(other.Statements, (a,b) => (a,b)))
                if (!a.StructuralEquals(b))
                    return false;

            if (tile.Inputs.Count != other.Inputs.Count)
                return false;

            foreach(var (a,b) in tile.Inputs.Zip(other.Inputs, (a,b) => (a, b)))
                if (!a.StructuralEquals(b))
                    return false;

            if (tile.Outputs.Count != other.Outputs.Count)
                return false;

            foreach (var (a, b) in tile.Outputs.Zip(other.Outputs, (a, b) => (a, b)))
                if (!a.StructuralEquals(b))
                    return false;

            return true;
        }
    }
}
