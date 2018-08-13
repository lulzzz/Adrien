using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Sawmill.Expressions;
using Xunit;

namespace Adrien.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void CanFlatten()
        {
            int[,] a = { { 1, 2, 3, 4 }, { 0, 0, 5, 7 } };
            IEnumerable<int> f = a.Flatten<int>();
            Assert.Equal(8, f.Count());
        }

        [Fact]
        public void CanReproSawmillIssue()
        {
            var expr2 = Expression.Add(Expression.Convert(Expression.Multiply(Expression.Constant(5), Expression.Constant(6)), typeof(long)), Expression.Constant(4L));
            var expr = Expression.Call(typeof(System.Math).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "Log10").First(), Expression.Constant(9.0));
            Assert.Throws<ArgumentOutOfRangeException>(() => expr.SelfAndDescendants().OfType<ConstantExpression>().Count());
        }
    }
}
