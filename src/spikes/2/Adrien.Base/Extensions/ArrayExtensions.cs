using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Adrien
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> Flatten<T>(this Array array)
        {
            return array.Cast<T>();
        }
    }
}
