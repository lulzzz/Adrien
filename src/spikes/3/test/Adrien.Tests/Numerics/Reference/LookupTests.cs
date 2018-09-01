using Adrien.Ast;
using Adrien.Numerics;
using Adrien.Numerics.Reference;
using Xunit;

namespace Adrien.Tests.Numerics.Reference
{
    public class LookupTests
    {
        public static (Tile tile, Tensor<int> input, Tensor<float> lookup, Tensor<float> res) LookupTile()
        {
            var input = new Symbol("input", 0);
            input.Shape = new Shape(ElementKind.Int32, new[] {16});
            var lookup = new Symbol("lookup", 1);
            lookup.Shape = new Shape(ElementKind.Float32, new[] {4});
            var res = new Symbol("res", 2);
            res.Shape = new Shape(ElementKind.Float32, new[] {16});

            var i = new Index("i");
            i.Ranges = new[] {new Range(0, 16)};

            var statement = new Statement(
                StatementKind.Assign,
                // left
                new Element(res,
                    new[] {new IndexExpression(i)}),
                // right
                new ElementExpression(
                    new Element(lookup, new[]
                    {
                        new IndexExpression(
                            new Element(input, new[] {new IndexExpression(i),})
                        )
                    })));

            var tile = new Tile("lookup", new[] {statement});

            var allocator = new TensorAllocator();
            var tinput = (Tensor<int>) allocator.Create(input.Shape, "input");
            var si = tinput.Buffer.Span;
            for (int n = 0; n < 16; n++)
                si[n] = n % 4;

            var tlookup = (Tensor<float>) allocator.Create(lookup.Shape, "lookup");
            var sl = tlookup.Buffer.Span;
            for (int m = 0; m < 4; m++)
                sl[m] = -m;

            var tres = (Tensor<float>) allocator.Create(res.Shape, "res");

            return (tile, tinput, tlookup, tres);
        }

        public static void CheckRes(Tensor<float> res)
        {
            var sr = res.Buffer.Span;

            for (var n = 0; n < 16; n++)
            {
                Assert.Equal((float)(-(n % 4)), sr[n]);
            }
        }

        [Fact]
        public void LookupExpression()
        {
            var compiler = new TileCompiler();
            var (tile, input, lookup, res) = LookupTile();

            var kernel = compiler.Compile(tile);

            var tensors = new ITensor[] {input, lookup, res};

            kernel.Eval(tensors);
            CheckRes(res);
        }
    }
}