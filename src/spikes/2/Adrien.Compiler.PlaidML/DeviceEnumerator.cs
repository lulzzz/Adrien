using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceEnumerator : PlaidMLApi<DeviceEnumerator>
    {
        public DeviceEnumerator(Context ctx) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocDeviceEnumeratorWithConfig(context, context.settings.Config, IntPtr.Zero, IntPtr.Zero);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_device_enumerator_with_config");
            }
            else
            {
                IsAllocated = true;
            }
        }

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeDeviceEnumerator(ptr);
        }
        #endregion

        #region Properties
        public List<DeviceConfig> ValidDevices
        {
            get
            {

                int count = (int) plaidml.__Internal.PlaidmlGetDevconfCount(this.context, this, true);
                if (count == 0)
                {
                    throw new Exception("plaidml_get_devconf_count returned 0 devices.");
                }
                List<DeviceConfig> vd = new List<DeviceConfig>(count);
                for (int i = 0; i < count; i++)
                {
                    vd.Add(new DeviceConfig(context, this, (ulong) i));
                }
                return vd;
            }
        }
        public List<DeviceConfig> InvalidDevices { get; protected set; }
        #endregion


    }
}
