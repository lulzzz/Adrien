using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceConfig : PlaidMLApi<DeviceConfig>
    {
        #region Constructors
        public DeviceConfig(Context ctx, DeviceEnumerator enumerator, ulong index, string config = "") : base(ctx, config)
        {
                       ptr = plaidml.__Internal.PlaidmlGetDevconf(context, enumerator, index);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_get_devconf");
            }
            else
            {
                Enumerator = enumerator;
                Index = index;
                IsAllocated = true;
            }
            
        }
        #endregion

        #region Overriden members
        public override void Free()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public DeviceEnumerator Enumerator { get; protected set; }

        public ulong Index { get; protected set; }

        public int Id
        {
            get
            {
                unsafe
                {
                    ulong* sizeRequired = stackalloc ulong[0];
                    bool r = plaidml.__Internal.PlaidmlQueryDevconf(context, this, PlaidmlDeviceProperty.PLAIDML_DEVICE_ID, IntPtr.Zero, 0, sizeRequired);
                    return 0;
                }
            }
        }
        #endregion
    }
}
