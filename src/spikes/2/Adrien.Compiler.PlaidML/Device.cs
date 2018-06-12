using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Device : PlaidMLApi<Device>
    {
        #region Constructors
        public Device(Context ctx, DeviceConfig devconf = null) : base(ctx)
        {
            if (devconf != null)
            {
                ptr = plaidml.__Internal.PlaidmlOpenDevice(context, devconf);
            }
            else
            {
                ptr = plaidml.__Internal.PlaidmlOpenDevice(context, IntPtr.Zero);
            }
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_open_device");
                return;
            }
            else
            {
                DeviceConfig = devconf;
                Buffers = new List<Buffer>();
                IsAllocated = true;
                IsOpen = true;
            }
        }


        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            if (this.IsOpen)
            {
                this.Close();
            }
        }
        #endregion

        #region Properties
        public DeviceConfig DeviceConfig { get; protected set; }
        public bool IsOpen { get; protected set; }
        public bool IsClosed { get; protected set; }

        public List<Buffer> Buffers { get; protected set; }
        #endregion

        #region Methods
        internal void ThrowIfNotOpen()
        {
            if (!this.IsOpen)
            {
                throw new InvalidOperationException("This device is not open.");
            }
        }

        public void Close()
        {
            ThrowIfNotAllocated();
            ThrowIfNotOpen();
            if (Buffers != null && Buffers.Count > 0)
            {
                Buffers.ForEach(buffer => buffer.Free());
            }
            plaidml.__Internal.PlaidmlCloseDevice(this);
            this.IsOpen = false;
            this.IsClosed = true;
        }

        public void CreateBuffer(Shape shape)
        {
            Buffer buffer = new Buffer(this.context, this, shape);
            if (buffer.IsAllocated)
            {
                this.Buffers.Add(buffer);
            }
        }

        #endregion

    }
}
