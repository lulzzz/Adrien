using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceEnumerator : PlaidMLApi<DeviceEnumerator>
    {
        #region Constructors
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
        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeDeviceEnumerator(ptr);
            ptr = IntPtr.Zero;
        }
        #endregion

        #region Properties
        public int Count
        {
            get
            {
                ThrowIfNotAllocated();
                return (int)plaidml.__Internal.PlaidmlGetDevconfCount(this.context, this, true);
            }
        }

        public List<DeviceConfig> ValidDevices
        {
            get
            {

                int count = (int)plaidml.__Internal.PlaidmlGetDevconfCount(this.context, this, true);
                if (count == 0)
                {
                    return null;
                }
                List<DeviceConfig> vd = new List<DeviceConfig>(count);
                for (int i = 0; i < count; i++)
                {
                    vd.Add(new DeviceConfig(context, this, (ulong)i));
                }
                return vd;
            }
        }
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
