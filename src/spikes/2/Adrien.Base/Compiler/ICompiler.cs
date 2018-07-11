using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface ICompiler
    {
        Dictionary<string, object> Options { get; }

        ITensorContext TensorContext { get; }

        bool Initialized { get; }
       
        bool Compile<T>(IKernel<T> kernel, out IRunnable<T> result)  where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible;
    }
}
