using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using System.Linq;
using System.Linq.Expressions;
using Xunit;

using Adrien.Notation;

namespace Adrien.Tests
{
    public class ExpressionVisitorTests
    {
        [Fact]
        public void CanConstructTensorIndexExpressionTree()
        {

            var A = Tensor.TwoD("A", (4, 3), "a", out Index a, out Index b);
            var B = Tensor.TwoD("B", (6, 7));
            var C = Tensor.TwoD("C", (8, 9));
            TensorExpression te = A[a, b];
            Assert.Equal(1, te.Tensors.Count());
            Assert.Equal(A, te.Tensors.First());
            TensorExpressionVisitor v = new TensorExpressionVisitor(te);
            v.Visit();
        }
    }
}
