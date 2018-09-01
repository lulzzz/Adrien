using System.Collections.Generic;

namespace Adrien.Ast.Extensions
{
    public static class HashSetExtensions
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> range)
        {
            foreach (var e in range)
                hashSet.Add(e);
        }
    }
}
