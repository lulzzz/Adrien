using System;

namespace Adrien.Compiler
{
    public interface IRunnable<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        RunStatus Run(IVariable<T> output, params IVariable<T>[] input);

        RunStatus Run(IVariable<T> output, ref IVariable<T> gradient, params IVariable<T>[] input);

        string RunStatusMessage { get; }
    }
}