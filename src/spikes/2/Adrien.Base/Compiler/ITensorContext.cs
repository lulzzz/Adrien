using System;
using System.Collections.Generic;
using System.Buffers;
using System.Text;

namespace Adrien.Compiler
{
    public interface ITensorContext
    {
        List<INDArray> Tensors { get; }
    }
}
