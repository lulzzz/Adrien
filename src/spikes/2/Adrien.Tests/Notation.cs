using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Text;

using Xunit;

using Adrien.Notation;

namespace Adrien.Tests
{
    public class NotationTests
    {
        

        [Fact]
        public void CanConstructTensorNotation()
        {
            Tensor<float> A = Tensor<float>.TwoD("A", "a", out Index a, out Index b );
            Assert.Equal("A", A.Name);
            Assert.Equal(2, A.Rank);
            Assert.Equal("a", a.Name);
            Assert.Equal("b", b.Name);
            var g = A[a, b];

            var B = Tensor<float>.ThreeD("B", out var ijk);
            var C = Tensor<float>.ThreeD("C");
            var D = Tensor<float>.ThreeD("C");
            D[ijk] = A[ijk];
            var (i, j, k) = ijk;
            //Assert.Equal("i", i.Name);
        }
        
    }
}
