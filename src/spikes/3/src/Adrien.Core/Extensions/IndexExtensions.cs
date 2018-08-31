using System.Linq;

namespace Adrien.Core.Extensions
{
    public static class IndexExtensions
    {
        public static bool StructuralEquals(this Index index, Index other)
        {
            if (index == null && other == null)
                return true;

            if (!index.Name.Equals(other.Name))
                return false;

            if (index.Ranges.Count != other.Ranges.Count)
                return false;

            foreach (var (a, b) in index.Ranges.Zip(other.Ranges, (a, b) => (a, b)))
                if (!a.StructuralEquals(b))
                    return false;

            return true;
        }

        public static bool IsComplex(this Index index)
        {
            return index.Ranges.Count > 1;
        }
    }
}
