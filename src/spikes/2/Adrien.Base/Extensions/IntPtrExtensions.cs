using System;

namespace Adrien
{
    public static class IntPtrExtensions
    {
        public static bool IsZero(this IntPtr ptr)
        {
            return (ptr == IntPtr.Zero);
        }

        public static bool IsNotZero(this IntPtr ptr)
        {
            return (ptr != IntPtr.Zero);
        }
    }
}
