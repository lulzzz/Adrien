using System;
using System.Collections.Generic;
using Adrien.Core.Fluent;
using Adrien.Core.Geometric;
using Adrien.Core.Numerics;
using Adrien.Core.Optimization;
using Xunit;

namespace Adrien.Core.Tests.Fluent
{

    public static class Layers
    {
        public static FTile Dense()
        {
            var layer = new FTile();
            var (input, w, b, res) = FSymbol.New("input", "W", "b", "res");
            layer.Sum((i, j) => res[i, j] = w[i, j] * input[j] + b[i]);
            layer.Sum(i => res[i] = Activations.ReLU(res[i]));

            return layer;
        }

        public static FTile SquareError()
        {
            var layer = new FTile();
            var (input, res) = FSymbol.New("input", "res");
            layer.Sum((i,j) => res[i] = input[j] * input[j]);

            return layer;
        }

    }

    public static class Activations
    {
        public static FElementExpression ReLU(FElementExpression expr)
        {
            throw new NotImplementedException();
        }
    }

    class MyImageReader : IDataBinder
    {
        private readonly List<float[,]> _images;

        public int[] ChunkSizes => new[] {_images.Count};

        public MyImageReader(List<float[,]> images)
        {
            _images = images;
        }

        public void Bind(int chunk, int index, IReadOnlyDictionary<string, ITensor> tensors)
        {
            var input = tensors["input"];
            var image = _images[index];

            Span<float> span = stackalloc float[32 * 32];

            for(var i = 0; i < 32; i++)
            for (var j = 0; j < 32; j++)
                span[i * 32 + j] = image[i, j];

            input.Write(span, offset: 0);
        }
    }

    class MyDigitReader : IDataBinder
    {
        private int[] _results;

        public int[] ChunkSizes => new[] { _results.Length };

        public MyDigitReader(int count)
        {
            _results = new int[count];
        }

        public void Bind(int chunk, int index, IReadOnlyDictionary<string, ITensor> tensors)
        {
            var res = tensors["res"];

            Span<float> span = stackalloc float[10];
            res.Read(span, 0);

            var argmax = 0; // snipped 'argmax(span)'

            _results[index] = argmax;
        }
    }

    public class MyTileCompiler : ITileCompiler
    {
        public IKernel Compile(Tile tile) => throw new NotImplementedException();
        public ITensor Create(Shape shape, string name) => throw new NotImplementedException();
    }

    public class FGraphTest
    {
        [Fact]
        public void MiniEndToEnd()
        {
            // Building the graph
            var g = new FGraph();
            var input = g.New("input").AsInput().As2D(32, 32);
            var label = g.New("label").AsInput().As1D(10);
            var hidden1 = g.Do(Layers.Dense(), input).As1D(128);
            var hidden2 = g.Do(Layers.Dense(), hidden1).As1D(128);
            var res = g.Do(Layers.Dense(), hidden2).As("res").As1D(10);
            var err = g.Do(Layers.SquareError(), input, label).AsCriterion();

            var graph = g.Build();

            // Geometric inference
            var solver = new GeometricSolver();
            solver.Solve(graph);

            // Optimizing the flow
            var optimizer = new AdamOptimizer(new MyTileCompiler());
            var reader = new MyImageReader(/* dummy */ null);
            var flow = optimizer.Optimize(graph, reader);

            // Evaluating with the flow
            var writer = new MyDigitReader(/* dummy */ 0);
            flow.Evaluate(reader, writer);
        }
    }
}
