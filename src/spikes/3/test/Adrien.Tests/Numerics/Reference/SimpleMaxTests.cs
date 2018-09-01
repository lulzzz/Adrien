using Adrien.Ast;
using Adrien.Numerics;
using Adrien.Numerics.Reference;
using Xunit;

namespace Adrien.Tests.Numerics.Reference
{
    public class SimpleMaxTests
    {
        public static (Tile tile, Tensor<int> input, Tensor<int> res) SimpleMaxTile()
        {
            var tile = new Tile("max");

            var input = new Symbol("input");
            input.Shape = new Shape(ElementKind.Int32, new[] { 16 });
            var res = new Symbol("res");
            res.Shape = new Shape(ElementKind.Int32, new[] { 1 });

            tile.AddInput(input);
            tile.AddOutput(res);

            var i = new Index("i");
            i.Ranges = new[] { new Range(0, 16) };

            var statement = new Statement(
                StatementKind.Max,
                // left
                new Element(res,
                    new[] { new IndexExpression(0) }),
                // right
                new ElementExpression(
                    new Element(input, new[] { new IndexExpression(i) })));

            tile.Add(statement);

            var allocator = new TensorAllocator();
            var tinput = (Tensor<int>)allocator.Create(input.Shape, "input");
            var s = tinput.Buffer.Span;
            for (int n = 0; n < 16; n++)
                s[n] = n + 2;

            var tres = (Tensor<int>)allocator.Create(input.Shape, "res");

            return (tile, tinput, tres);
        }

        public static void CheckRes(Tensor<int> res)
        {
            var s = res.Buffer.Span;
            Assert.Equal(17, s[0]);
        }

        [Fact]
        public void MaxExpression()
        {
            var compiler = new TileCompiler();
            var (simpleMax, input, res) = SimpleMaxTile();

            var kernel = compiler.Compile(simpleMax);

            var tensors = new ITensor[] { input, res };

            kernel.Eval(tensors);
            CheckRes(res);
        }
    }
}
