using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface INDArray<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        int NDim { get; }

        int[] Shape { get; }

        int Size { get; }

        Type DType { get; }

        int ItemSize { get; }

        IVariable<T> Zeros();

        IVariable<T> Ones();

        IVariable<T> Random();
    }
}
