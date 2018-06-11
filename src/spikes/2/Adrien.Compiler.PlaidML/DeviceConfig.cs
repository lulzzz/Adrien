using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceConfig : PlaidMLApi<DeviceConfig>
    {
        #region Constructors
        public DeviceConfig(Context ctx, DeviceEnumerator enumerator, ulong index) : base(ctx)
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

        public string Id
        {
            get
            {
                if (_Id.IsNullOrEmpty())
                {
                    _Id = QueryStringProperty(PlaidmlDeviceProperty.PLAIDML_DEVICE_ID);
                }
                return _Id;
            }
        }

        public string Config
        {
            get
            {
                if (_Config.IsNullOrEmpty())
                {
                    _Config = QueryStringProperty(PlaidmlDeviceProperty.PLAIDML_DEVICE_CONFIG);
                }
                return _Config;
            }
        }

        public string Description
        {
            get
            {
                if (_Description.IsNullOrEmpty())
                {
                    _Description = QueryStringProperty(PlaidmlDeviceProperty.PLAIDML_DEVICE_DESCRIPTION);
                }
                return _Description;
            }
        }

        public string Details
        {
            get
            {
                if (_Details.IsNullOrEmpty())
                {
                    _Details = QueryStringProperty(PlaidmlDeviceProperty.PLAIDML_DEVICE_DETAILS);
                }
                return _Details;
            }
        }
        #endregion

        #region Methods
        public string QueryStringProperty(PlaidmlDeviceProperty property)
        {
            unsafe
            {
                ulong* sizeRequired = stackalloc ulong[1];
                bool r = plaidml.__Internal.PlaidmlQueryDevconf(context, this, property, IntPtr.Zero, 0, sizeRequired);
                if (!r)
                {
                    ReportApiCallError("plaidml_query_dev_conf");
                    return string.Empty;
                }
                else if (*sizeRequired == 0)
                {
                    return string.Empty;
                }
                else
                {
                    int bufferSize = (int)*sizeRequired;
                    IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
                    r = plaidml.__Internal.PlaidmlQueryDevconf(context, this, property, buffer, *sizeRequired, sizeRequired);
                    if (!r)
                    {
                        ReportApiCallError("plaidml_query_dev_conf");
                        return string.Empty;
                    }
                    else
                    {
                        return Marshal.PtrToStringAnsi(buffer);
                    }
                }
            }
        }
        #endregion

        #region Fields
        protected string _Id;
        protected string _Config;
        protected string _Description;
        protected string _Details;
        #endregion
    }
}
