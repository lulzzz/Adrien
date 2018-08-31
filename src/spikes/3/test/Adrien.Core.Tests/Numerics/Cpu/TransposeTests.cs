﻿using Adrien.Core.Numerics;
using Adrien.Core.Numerics.Cpu;
using Xunit;

namespace Adrien.Core.Tests.Numerics.Cpu
{
    public class TransposeTests
    {
        public static (Tile tile, Tensor<int> input, Tensor<int> res) TransposeTile()
        {
            var tile = new Tile("transpose");
            
            var input = new Symbol("input");
            input.Shape = new Shape(ElementKind.Int32, new []{ 16, 16});
            var res = new Symbol("res");
            res.Shape = new Shape(ElementKind.Int32, new[] { 16, 16 });

            tile.AddInput(input);
            tile.AddOutput(res);

            var i = new Index("i");
            i.Ranges = new[] { new Range(0, 16) };

            var j = new Index("j");
            j.Ranges = new[] { new Range(0, 16) };

            var statement = new Statement(
                StatementKind.ElementWise,
                // left
                new Element(res, 
                    new []{ new IndexExpression(j), new IndexExpression(i) }),
                // right
                new ElementExpression(
                    new Element(input, new [] { new IndexExpression(i), new IndexExpression(j), })));

            tile.Add(statement);

            var allocator = new CpuTensorAllocator();
            var tinput = (Tensor<int>)allocator.Create(input.Shape, "input");
            var s = tinput.Buffer.Span;
            for (int m = 0; m < 16; m++)
            for (int n = 0; n < 16; n++)
                s[m * 16 + n] = n - m;

            var tres = (Tensor<int>)allocator.Create(input.Shape, "res");

            return (tile, tinput, tres);
        }

        public static void CheckRes(Tensor<int> res)
        {
            var s = res.Buffer.Span;

            for (var m = 0; m < 16; m++)
            {
                for (var n = 0; n < 16; n++)
                {
                    Assert.Equal(m - n, s[m * 16 + n]);
                }
            }
        }

        [Fact]
        public void ElementWiseExpression()
        {
            var compiler = new CpuTileCompiler();
            var (transpose, input, res) = TransposeTile();

            var kernel = compiler.Compile(transpose);

            var tensors = new ITensor[] { input, res };

            kernel.Eval(tensors);
            CheckRes(res);
        }
    }
}
