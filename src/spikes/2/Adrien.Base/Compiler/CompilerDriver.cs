using System;

namespace Adrien
{
    public class CompilerDriver
    {
        public static ILog Logger { get; private set; }
        
        public static void SetLogger(Func<ILog> logger)
        {
            lock(setLogLock)
            {
                if (Logger == null)
                {
                    Logger = logger();
                }
            }
        }
        private static object setLogLock = new object();
    }
}