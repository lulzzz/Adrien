using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface INDArray
    {
        int NDim { get; }

        int[] Shape { get; }

        int Size { get; }

        Type DType { get; }

        int ItemSize { get; }

        IV Zeros();

        void Ones();

        void Random();
    }
}
