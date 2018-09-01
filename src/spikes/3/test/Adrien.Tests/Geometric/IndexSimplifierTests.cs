using Adrien.Ast;
using Adrien.Ast.Extensions;
using Adrien.Geometric;
using Xunit;

namespace Adrien.Tests.Geometric
{
    public class IndexSimplifierTests
    {
        public Tile ComplexLinear()
        {
            // linear 2D layer: res[i] = sum(a[i,j] * x[j] + b[i])

            var a = new Symbol("A", 0);
            a.Shape = new Shape(ElementKind.Float32, new[] {16, 32});

            var x = new Symbol("x", 1);
            x.Shape = new Shape(ElementKind.Float32, new[] {32});

            var b = new Symbol("b", 2);
            b.Shape = new Shape(ElementKind.Float32, new[] {16});

            var res = new Symbol("res", 3);
            res.Shape = new Shape(ElementKind.Float32, new[] {16});

            var i = new Index("i");
            i.Ranges = new[] {new Range(0, 16), new Range(0, 24), new Range(0, 16)};

            var j = new Index("j");
            j.Ranges = new[] {new Range(0, 32), new Range(0, 64)};

            var statement = new Statement(StatementKind.ZeroAndSum,
                // left
                new Element(res, new[] {new IndexExpression(i)}),
                // right
                new ElementExpression(BinaryExpressionKind.Add,
                    new ElementExpression(BinaryExpressionKind.Multiply,
                        new ElementExpression(new Element(a, new[] {new IndexExpression(i), new IndexExpression(j)})),
                        new ElementExpression(new Element(x, new[] {new IndexExpression(j)}))),
                    new ElementExpression(new Element(b, new[] {new IndexExpression(i)}))));

            return new Tile("linear", new[] {statement});
        }

        public Tile SimpleLinear()
        {
            // linear 2D layer: res[i] = sum(a[i,j] * x[j] + b[i])

            var a = new Symbol("A", 0);
            a.Shape = new Shape(ElementKind.Float32, new[] {16, 32});

            var x = new Symbol("x", 1);
            x.Shape = new Shape(ElementKind.Float32, new[] {32});

            var b = new Symbol("b", 2);
            b.Shape = new Shape(ElementKind.Float32, new[] {16});

            var res = new Symbol("res", 3);
            res.Shape = new Shape(ElementKind.Float32, new[] {16});

            var i_0 = new Index("i_0");
            i_0.Ranges = new[] {new Range(0, 16)};
            var i_1 = new Index("i_1");
            i_1.Ranges = new[] {new Range(0, 24)};
            var i_2 = new Index("i_2");
            i_2.Ranges = new[] {new Range(0, 16)};

            var j_0 = new Index("j_0");
            j_0.Ranges = new[] {new Range(0, 32)};
            var j_1 = new Index("j_1");
            j_1.Ranges = new[] {new Range(0, 64)};

            var statement = new Statement(StatementKind.ZeroAndSum,
                // left
                new Element(res, new[] {new IndexExpression(i_0), new IndexExpression(i_1), new IndexExpression(i_2)}),
                // right
                new ElementExpression(BinaryExpressionKind.Add,
                    new ElementExpression(BinaryExpressionKind.Multiply,
                        new ElementExpression(new Element(a, new[]
                        {
                            new IndexExpression(i_0), new IndexExpression(i_1), new IndexExpression(i_2),
                            new IndexExpression(j_0), new IndexExpression(j_1),
                        })),
                        new ElementExpression(new Element(x,
                            new[] {new IndexExpression(j_0), new IndexExpression(j_1),}))),
                    new ElementExpression(new Element(b,
                        new[] {new IndexExpression(i_0), new IndexExpression(i_1), new IndexExpression(i_2)}))));

            return new Tile("linear", new[] {statement});
        }

        [Fact]
        public void Simplify()
        {
            var complex = ComplexLinear();
            var simple = complex.Project();
            var expectedSimple = SimpleLinear();

            Assert.True(expectedSimple.StructuralEquals(simple));
        }
    }
}