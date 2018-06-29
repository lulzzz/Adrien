using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;
using Adrien.Diagrams;
using Adrien.Trees;

using Xunit;

namespace Adrien.Tests
{
    public class GraphDiagramTests
    {
        public GraphDiagramTests()
        {

        }

        [Fact]
        public void CanConstructGraphDiagram()
        {
            var A = Tensor.TwoD("A", (4, 3), "a", out Index a, out Index b);
            var B = Tensor.TwoD("B", (6, 7));
            var C = Tensor.TwoD("C", (8, 9));
            TensorExpression te = A[a, b];

            GraphDiagram d = new GraphDiagram(te.ToTree());
        }
    }
}
