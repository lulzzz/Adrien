using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IRunnable<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        IReadOnlyList<IVariable<T>> Output { get; }

        IReadOnlyList<IVariable<T>> Input { get; }

        bool Run();
    }
}
