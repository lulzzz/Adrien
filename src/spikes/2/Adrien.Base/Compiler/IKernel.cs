using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Compiler
{
    public interface IKernel<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        DeviceType DeviceType { get; }

        IExpressionTree ExpressionTree { get; }

        IReadOnlyList<IVariableShape> InputShapes { get; }

        IVariableShape OutputShape { get; set; }

        bool CompileBeforeRun { get; set; }

        ICompiler Compiler { get; }

        bool CompileSuccess { get; }

        IRunnable<T> CompilerResult { get; }

        bool Compile();
    }
}
