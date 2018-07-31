using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IRunnable<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        RunStatus Run(IVariable<T> output, params IVariable<T>[] input);

        RunStatus Run(IVariable<T> output, out IVariable<T> gradient, params IVariable<T>[] input);

        string RunStatusMessage { get; }
    }
}
