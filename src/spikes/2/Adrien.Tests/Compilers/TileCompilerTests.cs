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
        public void CanCompileTileCode()
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

            code = @"function(I)-> (O) {
                O = I * I;
            }";
            Assert.True(c.Compile(6, code, out result));
            O = new Vector("O", 6).Var(new int[6]);
            I = new Vector("I", 6).Var(2, 4, 6, 8, 10, 12);
            Assert.Equal(RunStatus.Success, result.Run(O, I));
            Assert.Equal(16, O[1]);
        }

        [Fact]
        public void CanCompileVectorKernel()
        {
            var (x, y) = new Vector(10).Two("x", "y");
            var (a, b) = new Scalar().Two("a","b");
            Kernel<int> k = new Kernel<int>(y, a * x + b);
            Assert.Equal(3, k.InputTensors.Count);
            Assert.Equal(y, k.OutputTensor);
            k = new Kernel<int>(y, a * x + b, new TileCompiler());
            Assert.True(k.Compile());
        }
    }
}
