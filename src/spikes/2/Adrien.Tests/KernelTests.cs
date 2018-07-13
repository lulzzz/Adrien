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

            var D = Tensor.ThreeD("D", (2, 2, 2));
            C[a, b] = A[a, b] * B[b, a];
            
            Kernel<int> k = new Kernel<int>(C);
            
            Assert.Equal(3, k.Tensors.Count);
            Assert.Equal(C, k.OutputTensor);
            Assert.Equal(2, k.InputTensors.Count);
            Assert.Equal("A", k[A].Label);
            Assert.Throws<ArgumentException>(() => k[D]);
            Assert.Equal(3, k[A].Rank);
            Assert.Equal(4, k[B].Stride[0]);
        }
    }
}
