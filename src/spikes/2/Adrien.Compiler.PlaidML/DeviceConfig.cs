using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceConfig : PlaidMLApi<DeviceConfig>
    {
        public DeviceConfig(Context ctx) : base(ctx) {}

        public override void Free()
        {
            throw new NotImplementedException();
        }
    }
}
