using System;
using System.Collections.Generic;

namespace Adrien.Numerics
{
    /// <summary>
    /// The compiled equivalent of a graph where tiles have
    /// been replaced by kernels, and where variables have been
    /// replaced by tensors.
    /// </summary>
    public class Flow
    {
        public IReadOnlyDictionary<string, IKernel> Kernels
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyDictionary<string, ITensor> Tensors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Operation> Operations
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Evaluate(IDataBinder reader, IDataBinder writer)
        {
            throw new NotImplementedException();
        }
    }
}
