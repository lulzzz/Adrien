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
            Tensor<float> A = Tensor<float>.TwoD("A", "i", out Index i, out Index j );
            var g = A[i] + A[j];
        }
        
    }
}
