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
        public void CanCompileVectorKernel()
        {
            string code = @"function(I[N])-> (O) {
                O[i: N] = +(I[k]), i - k < N;
            }";
            TileCompiler c = new TileCompiler();
            Assert.True(c.Compile(5, code, out IRunnable<int> result));
            var O = new Vector("O", 5).Var(new int[5]);
            var I = new Vector("I", 5).Var(1, 2, 3, 4, 5);
            Assert.Equal(RunStatus.Success, result.Run(O, I));
            Assert.Equal(I[0] + I[1] + I[2] + I[3], O[3]);
        }

        [Fact]
        public void CanCompileSimpleKernel()
        {
            var (A, B, C) = Tensor.ThreeD("A", (2, 2, 2), "a", out Index a, out Index b, out Index c)
                .Three();

            C[a, b] = A[a, b] * B[b, a];
            TileCompiler compiler = new TileCompiler();
            Assert.True(compiler.Initialized);
            Kernel<int> k = new Kernel<int>(compiler, C);
            Assert.True(k.Compile());
        }
    }
}
