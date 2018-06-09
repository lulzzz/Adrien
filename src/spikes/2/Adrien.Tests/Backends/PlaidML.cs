using System;

using Xunit;

using Adrien.Backend.PlaidML;
using Adrien.Backend.PlaidML.Bindings;

namespace Adrien.Tests
{
    public class PlaidMLBackendTests
    {
        [Fact]
        public void CanGetVersion()
        {
            string s = plaidml.PlaidmlGetVersion();
            Assert.False(string.IsNullOrEmpty(plaidml.PlaidmlGetVersion()));
        }

        [Fact(DisplayName = "Can construct Context")]
        public void CanCreateCtx()
        {
            Context ctx = new Context();
            Assert.True(ctx.IsAllocated);
            ctx.Free();
            Assert.False(ctx.IsAllocated);
        }
    }
}
