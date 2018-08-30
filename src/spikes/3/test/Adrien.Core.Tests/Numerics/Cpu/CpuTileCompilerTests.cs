using System;
using System.Collections.Generic;
using System.Text;
using Adrien.Core.Numerics.Cpu;
using Xunit;

namespace Adrien.Core.Tests.Numerics.Cpu
{
    public class CpuTileCompilerTests
    {
        public static Tile GetLinearTile()
        {
            // linear 2D layer

            var tile = new Tile("linear");

            var a = new Symbol("A");
            a.Shape = new Shape(ElementKind.Float32, new[] { 32, 16 });

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
            var j = new Index("j");
            var statement = new Statement(StatementKind.ZeroAndSum,
                // left
                new Element(res, new IndexExpression(i)),
                // right
                new ElementExpression(BinaryExpressionKind.Add,
                    new ElementExpression(BinaryExpressionKind.Multiply,
                        new ElementExpression(new Element(a, new IndexExpression(i), new IndexExpression(j))),
                        new ElementExpression(new Element(x, new IndexExpression(j)))),
                    new ElementExpression(new Element(b, new IndexExpression(j)))));

            tile.Add(statement);

            return tile;
        }

        [Fact]
        public void Compile()
        {
            var compiler = new CpuTileCompiler();
            var linear = GetLinearTile();

            compiler.Compile(linear);
        }
    }
}
