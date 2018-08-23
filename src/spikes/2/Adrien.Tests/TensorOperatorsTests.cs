using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Adrien.Notation;
using static Adrien.Notation.TensorOperators;

namespace Adrien.Tests
{
    public class TensorOperatorsTests
    {
        [Fact]
        public void CanContructContractionOperation()
        {
            var (x, ypred, yactual, yerror, yloss) = new Vector(5, out Index i).Five("x", "ypred", "yactual", "yerror",
                "yloss");
            var (a, b) = new Scalar().Two("a", "b");

            ypred.def = a * x + b;
            Assert.Equal(3, ypred.ElementwiseDefinition.Tensors.Count);
            yerror.def = SQUARE[yactual - ypred];
            Assert.Equal(4, yerror.ElementwiseDefinition.Tensors.Count); 
            yloss[i / 2] = SUM[yerror[i]];
            Assert.True(yloss.IsDefined);
            //TensorContraction c = yloss.ContractionDefinition.Expression;
            //Assert.True(c.Tensors.Count > 0);
            
        }

        [Fact]
        public void CanConstructMeanOperation()
        {
            var (M, N, O) = new Matrix(6, 6, out Index i, out Index j).Three();
            O.def = MEAN[M[i]];
        }
    }
}
