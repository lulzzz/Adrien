using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceEnumerator : PlaidMLApi<DeviceEnumerator>
    {
        public DeviceEnumerator(Context ctx, string config = "")
        {
            ctx.ThrowIfNotAllocated();
            if (config.IsNotNullOrEmpty())
            {
                ptr = plaidml.__Internal.PlaidmlAllocDeviceEnumeratorWithConfig(ctx, config, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                ptr = plaidml.__Internal.PlaidmlAllocDeviceEnumerator(ctx, IntPtr.Zero, IntPtr.Zero);
            }
            IsAllocated = ptr.IsNotZero();
        }

        #region Overriden members
        public override void Free()
        {
            plaidml.__Internal.PlaidmlFreeDeviceEnumerator(ptr);
        }
        #endregion


    }
}
