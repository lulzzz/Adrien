using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using System.Linq;
using System.Linq.Expressions;
using Xunit;


using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Tests
{
    public class TensorExpressionVisitorTests
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

            Assert.Equal(5, v.Tree.Count);
            Assert.Equal(TensorOp.Summation, v.Tree.OperatorNodeAtIndex(2).Op);
            Assert.NotNull(v.Tree.OperatorNodeAtIndex(2).Left);
            Assert.NotNull(v.Tree.OperatorNodeAtIndex(2).Right);
            Assert.IsType<Tensor>(v.Tree.ValueNodeAtIndex(3).Value);
            Assert.IsType<IndexSet>(v.Tree.ValueNodeAtIndex(4).Value);

            IndexSet s = v.Tree.ValueNodeAtIndex(4).ValueAs<IndexSet>();
            Assert.Equal(2, s.Indices.Count);
            Assert.Equal(4, s.Indices.ElementAt(0).Dimension);
            Assert.Equal("b", s.Indices.ElementAt(1).Name);
        }

        [Fact]
        public void CanParseBinaryExpression()
        {
            var A = Tensor.FiveD("A", (4, 3, 145, 11, 2), "a", out Index i, out Index j, out Index k, out Index l, out Index m);
            var B = Tensor.TwoD("B", (6, 7));
            var C = Tensor.ThreeD("C", (8, 9, 10));
            var O = B[i, j] * C[i, j, k];
            ExpressionTree tree = O.ToTree();
            Assert.Equal(9, tree.Count);
            Assert.Equal(TensorOp.Mul, tree.OperatorNodeAtIndex(2).Op);
            Assert.Equal(TensorOp.Summation, tree.OperatorNodeAtIndex(3).Op);
            Assert.Equal(TensorOp.Summation, tree.OperatorNodeAtIndex(6).Op);
            OperatorNode on = tree.OperatorNodeAtIndex(6);
            Assert.IsType<ValueNode>(on.Left);
            ValueNode vn = on.Left as ValueNode;
            Assert.Equal(ValueNodeType.TENSOR, vn.NodeType);
            Assert.Equal(C, vn.ValueAs<Tensor>());
        }
    }
}
