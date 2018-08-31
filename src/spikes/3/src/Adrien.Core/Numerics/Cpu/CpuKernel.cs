using System;
using System.Collections.Generic;

namespace Adrien.Core.Numerics.Cpu
{
    public class CpuKernel : IKernel
    {
        private readonly Action<IReadOnlyList<ITensor>> _kernel;

        public CpuKernel(Action<IReadOnlyList<ITensor>> kernel)
        {
            _kernel = kernel;
        }

        public void Eval(IReadOnlyList<ITensor> tensors)
        {
            _kernel(tensors);
        }
    }
}
