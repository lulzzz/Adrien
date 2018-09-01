namespace Adrien.Ast.Extensions
{
    public static class RangeExtensions
    {
        public static bool StructuralEquals(this Range range, Range other)
        {
            return range.Count == other.Count && range.Offset == other.Offset;
        }
    }
}
