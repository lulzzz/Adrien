using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceEnumerator : PlaidMLApi<DeviceEnumerator>
    {
        public DeviceEnumerator(Context ctx) : base(ctx)
        {
            if (context.settings.IsManualConfig)
            {
                ptr = plaidml.__Internal.PlaidmlAllocDeviceEnumeratorWithConfig(context, context.settings.Config, IntPtr.Zero, IntPtr.Zero);

            }
            else
            {
                ptr = plaidml.__Internal.PlaidmlAllocDeviceEnumerator(context, IntPtr.Zero, IntPtr.Zero);

            }
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

        #region Methods
        public string GetConfigSource()
        {
            IntPtr r = plaidml.__Internal.PlaidmlGetEnumeratorConfigSource(this);
            if (r.IsZero())
            {
                ReportApiCallError("plaidml_get_enumerator_config_source");
                return string.Empty;
            }
            else
            {
                return Marshal.PtrToStringAnsi(r);
            }
        }
        #endregion
    }
}
