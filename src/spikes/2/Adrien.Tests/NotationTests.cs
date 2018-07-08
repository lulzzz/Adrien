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
        }

        [Fact]
        public void CanUseFluentTensorConstruction()
        {
            Tensor D = Tensor.TwoD("D", (11, 12))
                .With(out Tensor E)
                .With(out Tensor F, 4, 3);

            Assert.Equal("D", D.Name);
            Assert.Equal(12, D.Dimensions[1]);

            Assert.Equal("E", E.Name);
            Assert.Equal(12, E.Dimensions[1]);

            Assert.Equal("F", F.Name);
            Assert.Equal(4, F.Dimensions[0]);
            Assert.Equal(3, F.Dimensions[1]);
            Assert.Equal(2, F.Rank);
            Assert.Throws<ArgumentException>(() => F.With(out Tensor G, 3, 2, 1));
            var (H, I, J) = Tensor.ThreeD("H", (2, 2, 2)).Three();
            Assert.Equal("H", H.Label);
            Assert.Equal("I", I.Label);
            Assert.Equal("J", J.Label);
            Assert.Equal(3, J.Rank);
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