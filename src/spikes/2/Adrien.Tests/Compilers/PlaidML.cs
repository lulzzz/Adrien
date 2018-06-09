using System;

using Xunit;

using Adrien.Compiler.PlaidML;
using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Tests
{
    public class PlaidMLCompilerTests
    {
        [Fact(DisplayName = "Can call PlaidML GetVersion")]
        public void CanGetVersion()
        {
            string s = plaidml.PlaidmlGetVersion();
            Assert.False(string.IsNullOrEmpty(plaidml.PlaidmlGetVersion()));
        }

        [Fact(DisplayName = "Can construct PlaidML Context class")]
        public void CanCreateCtx()
        {
            Context ctx = new Context();
            Assert.True(ctx.IsAllocated);
            ctx.Free();
            Assert.False(ctx.IsAllocated);
        }
    }
}
