using System;
using System.Collections.Generic;

namespace Adrien.Numerics.Reference
{
    public class Kernel : IKernel
    {
        private readonly Action<IReadOnlyList<ITensor>> _kernel;

        public Kernel(Action<IReadOnlyList<ITensor>> kernel)
        {
            _kernel = kernel;
        }

        public void Eval(IReadOnlyList<ITensor> tensors)
        {
            _kernel(tensors);
        }
    }
}
