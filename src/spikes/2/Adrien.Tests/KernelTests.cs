using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

using Adrien.Compiler;
using Adrien.Notation;

namespace Adrien.Tests
{
    public class KernelTests
    {
        [Fact]
        public void CanConstructKernel()
        {
            var (A, B, C) = Tensor.ThreeD("A", (2, 2, 2), "a", out Index a, out Index b, out Index c)
                .Three();
            

            C[a, b] = A[a, b] * B[b, a];
            Kernel<int> k = new Kernel<int>(C);
            
            Assert.Equal(C, k.OutputTensor);
            Assert.Equal(2, k.InputTensors.Count);

            var V1 = new Vector("V1", out Index i, 3).With(out Vector V2).With(out Vector V3);
            V3[i] = V1 + V2;
            Kernel<int> vk1 = new Kernel<int>(V3);
        }
    }
}
