using Serilog;

namespace Adrien
{
    public class CompilerDriver
    {
        public static ILog Log
        {
            get => _Log;
            set
            {
                if (_Log == null)
                {
                    _Log = value;
                }
            }
        
        }

        private static ILog _Log;
    }
}