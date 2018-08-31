using Adrien.Core.Numerics;
using Adrien.Core.Numerics.Cpu;
using Xunit;

namespace Adrien.Core.Tests.Numerics.Cpu
{
    public class CpuTileCompilerTests
    {
        public static (Tile, Tensor<float> a, Tensor<float> x, Tensor<float> b, Tensor<float> res) GetLinearTile()
        {
            // linear 2D layer: res[i] = sum(a[i,j] * x[j] + b[i])

            var tile = new Tile("linear");

            var a = new Symbol("A");
            a.Shape = new Shape(ElementKind.Float32, new[] { 16, 32 });

            var x = new Symbol("x");
            x.Shape = new Shape(ElementKind.Float32, new[] { 32 });

            var b = new Symbol("b");
            b.Shape = new Shape(ElementKind.Float32, new[] { 16 });

            var res = new Symbol("res");
            res.Shape = new Shape(ElementKind.Float32, new[] { 16 });

            tile.AddInput(a);
            tile.AddInput(x);
            tile.AddInput(b);
            tile.AddOutput(res);

            var i = new Index("i");
            i.Ranges = new[] {new Range(0, 16)};

            var j = new Index("j");
            j.Ranges = new[] {new Range(0, 32)};

            var statement = new Statement(StatementKind.ZeroAndSum,
                // left
                new Element(res, new []{new IndexExpression(i)}),
                // right
                new ElementExpression(BinaryExpressionKind.Add,
                    new ElementExpression(BinaryExpressionKind.Multiply,
                        new ElementExpression(new Element(a, new []{new IndexExpression(i), new IndexExpression(j)})),
                        new ElementExpression(new Element(x, new []{new IndexExpression(j)}))),
                    new ElementExpression(new Element(b, new []{new IndexExpression(i)}))));

            tile.Add(statement);

            var allocator = new CpuTensorAllocator();
            var ta = (Tensor<float>)allocator.Create(a.Shape, "a");
            var sa = ta.Buffer.Span;
            for(int m = 0; m < 16; m++)
            for (int n = 0; n < 32; n++)
                sa[m * 32 + n] = (n + m) % 2;

            var tx = (Tensor<float>)allocator.Create(x.Shape, "x");
            var sx = tx.Buffer.Span;
            for (int n = 0; n < 32; n++)
                sx[n] = n % 3;

            var tb = (Tensor<float>)allocator.Create(b.Shape, "b");
            var sb = tb.Buffer.Span;
            for (int m = 0; m < 16; m++)
                sb[m] = m % 5;

            var tres = (Tensor<float>)allocator.Create(res.Shape, "res");

            return (tile, ta, tx, tb, tres);
        }

        public static void CheckRes(Tensor<float> res)
        {
            var sr = res.Buffer.Span;

            for (var m = 0; m < 16; m++)
            {
                var myRes = 0f;
                for (var n = 0; n < 32; n++)
                {
                    var va = (n + m) % 2;
                    var vx = n % 3;
                    var vb = m % 5;
                    myRes += va * vx + vb;
                }

                Assert.Equal(myRes, sr[m]);
            }
        }

        [Fact]
        public void SumExpression()
        {
            var compiler = new CpuTileCompiler();
            var (linear, a, x, b, res) = GetLinearTile();

            var kernel = compiler.Compile(linear);

            var tensors = new ITensor[] {a, x, b, res};

            kernel.Compute(tensors);
            CheckRes(res);
        }

        [Fact]
        public void ZeroAndSum()
        {
            var compiler = new CpuTileCompiler();
            var (linear, a, x, b, res) = GetLinearTile();

            var kernel = compiler.Compile(linear);

            var tensors = new ITensor[] { a, x, b, res };

            var sr = res.Buffer.Span;
            for (var i = 0; i < sr.Length; i++)
                sr[i] = i; // non-zero initialization

            kernel.Compute(tensors);

            // correct only if 'res' is re-initialized before the sum
            CheckRes(res);
        }
    }
}
