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
            
            Assert.Equal(3, k.Tensors.Count);
            Assert.Equal(C, k.OutputTensor);
            Assert.Equal(2, k.InputTensors.Count);
            Assert.Equal(8, k[A].Size);
            k[A].Ones();
            Assert.Equal(1, k.Input[0][0]);
            k[A].Zeros();
            Assert.Equal(0, k.Input[0][0]);
        }
    }
}
