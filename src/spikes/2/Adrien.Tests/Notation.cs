﻿using System;
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
            Tensor A = Tensor.TwoD("A", (7,7), "a", out Index a, out Index b);
            Assert.Equal("A", A.Name);
            Assert.Equal(2, A.Rank);
            Assert.Equal("a", a.Name);
            Assert.Equal("b", b.Name);
            var A1 = A[a, b];
            Assert.IsType<IndexExpression>((Expression) A1);
            var B = Tensor.ThreeD("B", (5, 6, 7), "i", out var ijk);
            var (i, j, k) = ijk;
            Assert.Equal("i", i.Name);
            Assert.Equal("j", j.Name);
            Assert.Equal("k", k.Name);
            Assert.IsType<IndexExpression>((Expression) B[i]);
            Assert.IsType<IndexExpression>((Expression) B[ijk]);

            Tensor C = Tensor.ThreeD("C", (5, 6, 7), "a", out IndexSet abc);
            Assert.IsType<IndexExpression>((Expression) C[abc]);
        }

        [Fact]
        public void CanGenerateTermNames()
        {
            var B = Tensor.FiveD(tn.B, (4, 5, 6, 7, 8));
            Assert.Equal("B", B.Name);
            var I = new IndexSet("m0", B.Dimensions);
            Assert.Equal("m1", I[0].Name);
            var J = new IndexSet("i0", B.Dimensions);
            Assert.Equal("i1", J[0].Name);
            var (m1, m2, m3, m4, m5) = I;
            Assert.Equal("m4", m4.Name);
        }

        [Fact]
        public void CanAssignTensorExpression()
        {
            var A = Tensor.TwoD("A", (4,3), "a", out Index a, out Index b);
            var B = Tensor.TwoD("B", (6,7));
            var C = Tensor.TwoD("C", (8,9));
            C[a,b] = B[a,b] * C[b,a];
            Assert.True(C.IsAssigned);
        }
    }
}