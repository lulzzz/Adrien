using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Adrien.Tests
{
    public class Extensions
    {
        [Fact]
        public void CanFlatten()
        {
            int[,] a = { { 1, 2, 3, 4 }, { 0, 0, 5, 7 } };
            IEnumerable<int> f = a.Flatten<int>();
            Assert.Equal(8, f.Count());
        }
    }
}
