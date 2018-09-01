using System.Collections.Generic;

namespace Adrien.Numerics
{
    /// <summary>
    /// A function that operates through side-effects on the
    /// list of tensors passed as argument. Kernels are dependent
    /// on the choice of a specific backend for Adrien.
    /// </summary>
    public interface IKernel
    {
        void Eval(IReadOnlyList<ITensor> tensors);
    }
}
