using System;
using System.Collections.Generic;
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
            var A = Tensor.ThreeD("A", (10, 11, 12), "a", out Index a, out Index b, out Index c)
                        .With(out Tensor B)
                        .With(out Tensor C);
            C[a, b] = A[a, b] * B[b, a];
            Kernel<int> k = new Kernel<int>(C);

            Assert.Equal(C, k.OutputTensor);
        }
    }
}
