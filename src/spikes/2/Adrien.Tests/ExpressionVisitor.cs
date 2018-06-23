using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using System.Linq.Expressions;
using Xunit;

using Adrien.Notation;

namespace Adrien.Tests
{
    public class ExpressionVisitorTests
    {
        [Fact]
        public void CanGetVariables()
        {

            var A = Tensor.TwoD("A", (4, 3), "a", out Index a, out Index b);
            var B = Tensor.TwoD("B", (6, 7));
            var C = Tensor.TwoD("C", (8, 9));
            TensorExpression te = C[a, b] = B[a, b] * C[b, a];
            TensorExpressionVisitor v = new TensorExpressionVisitor(te);
            v.Visit(te);
        }
    }
}
