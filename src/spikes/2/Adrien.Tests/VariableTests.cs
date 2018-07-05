using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using Adrien.Compiler;
using Adrien.Notation;

namespace Adrien.Tests
{
    public class VariableTests
    {
        [Fact]
        public void CanConstructVariable()
        {
            int[,] array1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] array2 = new int[,] { { 1, 2, 3 } };
            var V1 = new Vector();
            Assert.Throws<ArgumentException>(() => new Var<UInt64>(V1, array1));
            Assert.Throws<ArgumentException>(() => new Var<UInt64>(V1, array2));
            var A = Tensor.TwoD("A", (4, 3), "a", out Index a, out Index b);
            Assert.True(new Var<int>(A, array1).Initialized);
        }
    }
}
