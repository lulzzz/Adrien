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
        public void CanParseIndexExpression()
        {
            var A = Tensor.TwoD("A", (4, 3), "a", out Index a, out Index b);
            var B = Tensor.TwoD("B", (6, 7));
            var C = Tensor.TwoD("C", (8, 9));
            TensorExpression te = A[a, b];
            Assert.Single(te.Tensors);
            Assert.Equal(A, te.Tensors.First());
            TensorExpressionVisitor v = new TensorExpressionVisitor(te);
            Assert.Equal(3, v.Tree.Count);
            Assert.Equal(Trees.Op.Summation, v.Tree.OperatorNodeAt(0).Op);
            Assert.IsType<Tensor>(v.Tree.ValueNodeAt(1).Value);
            Assert.IsType<IndexSet>(v.Tree.ValueNodeAt(2).Value);
            IndexSet s = v.Tree.ValueNodeAt(2).Value as IndexSet;
            Assert.Equal(2, s.Indices.Count);
            Assert.Equal(4, s.Indices.ElementAt(0).Dimension);
            Assert.Equal("b", s.Indices.ElementAt(1).Name);
        }
    }
}
