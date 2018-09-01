using Adrien.Ast;
using Adrien.Numerics;
using Adrien.Numerics.Reference;
using Xunit;

namespace Adrien.Tests.Numerics.Reference
{
    public class TransposeTests
    {
        public static (Tile tile, Tensor<int> input, Tensor<int> res) TransposeTile()
        {
            var input = new Symbol("input", 0);
            input.Shape = new Shape(ElementKind.Int32, new[] {16, 16});
            var res = new Symbol("res", 1);
            res.Shape = new Shape(ElementKind.Int32, new[] {16, 16});

            var i = new Index("i");
            i.Ranges = new[] {new Range(0, 16)};

            var j = new Index("j");
            j.Ranges = new[] {new Range(0, 16)};

            var statement = new Statement(
                StatementKind.Assign,
                // left
                new Element(res,
                    new[] {new IndexExpression(j), new IndexExpression(i)}),
                // right
                new ElementExpression(
                    new Element(input, new[] {new IndexExpression(i), new IndexExpression(j),})));

            var tile = new Tile("transpose", new[] {statement});

            var allocator = new TensorAllocator();
            var tinput = (Tensor<int>) allocator.Create(input.Shape, "input");
            var s = tinput.Buffer.Span;
            for (int m = 0; m < 16; m++)
            for (int n = 0; n < 16; n++)
                s[m * 16 + n] = n - m;

            var tres = (Tensor<int>) allocator.Create(input.Shape, "res");

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
            var compiler = new TileCompiler();
            var (transpose, input, res) = TransposeTile();

            var kernel = compiler.Compile(transpose);

            var tensors = new ITensor[] {input, res};

            kernel.Eval(tensors);
            CheckRes(res);
        }
    }
}