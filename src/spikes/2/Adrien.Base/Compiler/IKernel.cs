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

        IVariable<T> Output { get; }

        IReadOnlyList<IVariable<T>> Input { get; }
    }
}
