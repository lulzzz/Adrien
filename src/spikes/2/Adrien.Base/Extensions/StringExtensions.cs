using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static void ThrowIfEmpty(this string s, string message)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
