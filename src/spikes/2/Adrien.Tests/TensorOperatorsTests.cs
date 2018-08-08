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

            ypred[x] = a * x + b;
            Assert.Equal(3, ypred.ElementwiseDefinition.Expression.Tensors.Count);
            yerror[ypred, yactual] = Pow2[yactual[i] - ypred];
            Assert.Equal(4, yerror.ElementwiseDefinition.Expression.Tensors.Count);
            yloss[i] = yerror[i];
            Assert.True(yloss.IsAssigned);
            TensorContraction c = yloss.ContractionDefinition.Expression;
            Assert.True(c.Tensors.Count > 0);
        }

        [Fact]
        public void CanConstructMeanOperation()
        {
            var (x, ypred, yactual, yerror, yloss) = new Vector(5, out Index i).Five("x", "ypred", "yactual", "yerror",
               "yloss");
            var (a, b) = new Scalar().Two("a", "b");

            ypred[x] = a * x + b;
            yerror[ypred, yactual] = Pow2[yactual - ypred];
            yloss[yerror] = Avg[yerror[i]];
            Assert.True(yloss.IsAssigned);
            TensorExpression texpr = yloss.ElementwiseDefinition.Expression;
            Assert.Equal(2, texpr.Tensors.Count);


        }
    }
}
