using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using Adrien.Log;
using Adrien.Notation;
using static Adrien.Notation.Operators;

using Adrien.Compiler;
using Adrien.Compiler.PlaidML;
namespace Adrien.Tests
{
    public class TensorExpressionTests
    {
        public TensorExpressionTests()
        {
            CompilerDriver.SetLogger(() => SerilogLogger.CreateDefaultLogger("Adrien.Tests.log"));
        }

        [Fact]
        public void CanCompileLinearRegressionKernel()
        {
            TileCompiler compiler = new TileCompiler();
            var (yactual, x) = new Vector(5, out Index i).Two("yactual", "x");
            Scalar a = new Scalar("a"), b = new Scalar("b");
            var ypred = a * x + b;
            var yloss = MEAN[SQUARE[yactual - ypred]];
            Kernel<int> loss = new Kernel<int>(yloss, compiler);
            Assert.True(loss.Compile());
        }
    }
}
