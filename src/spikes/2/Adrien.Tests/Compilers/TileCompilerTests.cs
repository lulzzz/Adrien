using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using Adrien.Log;
using Adrien.Notation;
//using static Adrien.Notation.Math;
using static Adrien.Notation.TensorOperators;

using Adrien.Compiler;
using Adrien.Compiler.PlaidML;


namespace Adrien.Tests.Compilers
{
    public class TileCompilerTests
    {
        public TileCompilerTests()
        {
            CompilerDriver.SetLogger(() => SerilogLogger.CreateDefaultLogger("Adrien.Tests.log"));
        }

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

            code = @"
                   function(I0[N], I1[N])-> (O) {
                        S = (I1 - I0) * (I1 - I0);
                        O[n:N] = +(S[n]);
                   }";
            Assert.True(c.Compile(2, 6, code, out result));
            var I0 = new Vector("I0", 6).Var(1, 2, 3, 4, 5, 6);
            var I1 = new Vector("I1", 6).Var(5, 5, 6, 6, 7, 7);
            Assert.Equal(RunStatus.Success, result.Run(O, I0, I1));
            Assert.Equal(16, O[0]);
            Assert.Equal(9, O[1]);
            //I.=l
        }

        [Fact]
        public void CanCompileVectorKernel()
        {
            var (x, y) = new Vector(5).Two("x", "y");
            var (a, b) = new Scalar().Two("a","b");
            Kernel<int> k = new Kernel<int>(y, a * x + b);
            Assert.Equal(3, k.InputTensors.Count);
            Assert.Equal(y, k.OutputTensor);
            k = new Kernel<int>(y, a * x + b, new TileCompiler());

            Assert.True(k.Compile());
            var vy = y.Var(new int[5]);
            var vx = x.Var(1, 2, 3, 4, 5);
            var va = a.Var(2);
            var vb = b.Var(1);
            Assert.Equal(RunStatus.Success, k.CompilerResult.Run(vy, va, vx, vb ));
            Assert.Equal(3, vy[0]);
            Assert.Equal(5, vy[1]);

            var predict = k.Func3;
            var r = predict(3, new int[5] { 2, 4, 6, 8, 10 }, 2);
            Assert.Equal(8, r[0]);

            var (y1, y2) = new Vector(5).Two("y1", "y2");
            var kloss = new Kernel<int>(y, Pow2[y2 - y1]);
        }

        [Fact]
        public void CanComputeGradient()
        {
            string code = @"function(I)-> (O) {
                O = I * I;
            }";
            TileCompiler c = new TileCompiler();
            Assert.True(c.Compile(5, code, out IRunnable<int> result));
            var O = new Vector("O", 5).Var(new int[5]);
            IVariable<int> G = new Vector("G", 5).Var(new int[5]);
            var I = new Vector("I", 5).Var(1, 2, 3, 4, 5);
            Assert.Equal(RunStatus.Success, result.Run(O, ref G, I));
            Assert.Equal(8, G[3]);
        }

        [Fact]
        public void CanCompileLinearRegressionKernel()
        {
            TileCompiler compiler = new TileCompiler();
            var (x, ypred, yactual, yerror, yloss) = new Vector(5, out Index i).Five("x", "ypred", "yactual", "yerror", 
                "yloss");
            var (a, b) = new Scalar().Two("a", "b");

            ypred.def = (a * x + b);
            Kernel<int> predict = new Kernel<int>(ypred, compiler);

            yerror.def = Pow2[yactual - ypred];
            Kernel<int> error = new Kernel<int>(yerror, compiler);
            Assert.True(error.Compile());

            Assert.Contains(a, error.InputShapes);
            Assert.Contains(b, error.InputShapes);
            Assert.Contains(x, error.InputShapes);
            Assert.Contains(yactual, error.InputShapes);
            Assert.Equal(4, error.InputShapes.Count);
            Assert.Equal(yerror, error.OutputShape);

            var va = a.Var(5);
            var vb = b.Var(6);
            var vx = x.Var(1, 2, 3, 4, 5);
            var vya = yactual.Var(new [] { 10, 20, 30, 40, 50 });
            var vyerror = yerror.Var<int>();
            Assert.Equal(RunStatus.Success, error.CompilerResult.Run(vyerror, vya, va, vx, vb));
            Assert.Equal(System.Math.Pow(vya[0] - ((5 * 1) + 6), 2), vyerror[0]);

            for (int index = 0; index < vyerror.ElementCount; index++)
            {
                Assert.Equal(System.Math.Pow(vya[index] - ((va * vx[index]) + vb), 2), vyerror[index]);
            }

            yloss.def = Mean[yerror[i]];
            Kernel<int> loss = new Kernel<int>(yloss, compiler);
            Assert.True(loss.Compile());
            //Assert.Equal(RunStatus.Success, error.CompilerResult.Run(v, vya, va, vx, vb));

        }
    }
}
