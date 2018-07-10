using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using Adrien.Notation;
using Adrien.Compiler;
using Adrien.Compiler.PlaidML;


namespace Adrien.Tests.Compilers
{
    public class TileCompilerTests
    {
        [Fact]
        public void CanCompileSimpleKernel()
        {
            var (A, B, C) = Tensor.ThreeD("A", (2, 2, 2), "a", out Index a, out Index b, out Index c)
                .Three();

            C[a, b] = A[a, b] * B[b, a];
            Kernel<int> k = new Kernel<int>(C);
            TileCompiler<int> compiler = new TileCompiler<int>(k);
            Assert.True(compiler.Initialized);
            compiler.Compile();
        }
    }
}
