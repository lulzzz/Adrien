using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Tensor : PlaidMLApi<Tensor>
    {
        #region Constructors
        public Tensor(Device device, Shape shape, DeviceBuffer buffer = null) : base(device.Context)
        {
            if (buffer == null)
            {
                buffer = new DeviceBuffer(context, device, shape);
                if (!buffer.IsAllocated)
                {
                    Error("Could not allocate device buffer for tensor.");
                    return;
                }
            }
            ptr = plaidml.__Internal.PlaidmlAllocTensor(context, buffer, shape);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_tensor");
                return;
            }
            else
            {
                Device = device;
                Buffer = buffer;
                IsAllocated = true;
            }
        }
        #endregion

        #region Properties
        public Device Device { get; protected set; }
        public DeviceBuffer Buffer { get; protected set; }
        public Shape Shape { get; protected set; }
        #endregion

        #region Methods
        public MemoryView<T> CreateMemoryView<T>(bool discard = true) where T : unmanaged
        {
            return new MemoryView<T>(new MemoryMapping(Buffer, discard));
        }
        #endregion
    }
}
