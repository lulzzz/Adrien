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
            Tensor<float> A = Tensor<float>.TwoD("A", "a", out Index a, out Index b);
            Assert.Equal("A", A.Name);
            Assert.Equal(2, A.Rank);
            Assert.Equal("a", a.Name);
            Assert.Equal("b", b.Name);
            var A1 = A[a, b];
            Assert.IsType<IndexExpression>((Expression) A1);

            var B = Tensor<float>.ThreeD("B", "i", out var ijk);
            var (i, j, k) = ijk;
            Assert.Equal("i", i.Name);
            Assert.Equal("j", j.Name);
            Assert.Equal("k", k.Name);
            var C = Tensor<float>.ThreeD("C");
            var D = Tensor<float>.ThreeD("D");
            var Z = C[i];
            Assert.IsType<IndexExpression>((Expression)Z);
            var h = D[ijk];
            Assert.IsType<IndexExpression>((Expression) h);
            IndexExpression ih = (IndexExpression) h;
            //A[i, j] = B[i, j] + C[i, j];
            
            
        }
        
    }
}
