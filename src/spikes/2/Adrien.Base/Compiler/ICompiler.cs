using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface ICompiler<T> : IDisposable where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        Dictionary<string, object> Options { get; }

        bool Initialized { get; }
           
        bool Compile();
    }
}
