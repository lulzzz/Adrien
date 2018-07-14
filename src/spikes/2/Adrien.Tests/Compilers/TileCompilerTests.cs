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
        public void CanCompileCode()
        {
            string code = @"function(I[M, N])-> (O) {
                O[n: N] = > (I[m, n]);
            }";
            TileCompiler c = new TileCompiler();
            Assert.True(c.Compile(new Tensor("A", 5), new Tensor("B", 5), code, out IRunnable<int> result));
            var output = new Tensor(5).Var(new int[5]);
            result.Run(new IVariable<int>[] { new Tensor(5).Var(1, 2, 3, 4, 5) }, output);
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
