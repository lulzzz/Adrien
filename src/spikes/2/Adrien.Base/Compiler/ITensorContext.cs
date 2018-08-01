using System.Collections.Generic;

namespace Adrien.Compiler
{
    public interface ITensorContext
    {
        List<INDArray> Tensors { get; }
    }
}