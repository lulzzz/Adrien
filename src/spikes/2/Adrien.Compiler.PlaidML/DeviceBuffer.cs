using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceBuffer : PlaidMLApi<DeviceBuffer>
    {
        public Device Device { get; protected set; }

        public Shape Shape { get; protected set; }

        public ulong SizeInBytes { get; protected set; }
        
        public IntPtr BufferPointer
        {
            get
            {
                ThrowIfNotAllocated();
                return ptr;
            }
        }


        public DeviceBuffer(Context ctx, Device device, Shape shape) : base(ctx)
        {
            SizeInBytes = plaidml.__Internal.PlaidmlGetShapeBufferSize(shape);
            if (SizeInBytes == 0)
            {
                Error("plaidml_get_shape_buffer_size returned 0.");
                return;
            }
            ptr = plaidml.__Internal.PlaidmlAllocBuffer(_Context, device, SizeInBytes);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_buffer");
                return;
            }
            else
            {
                Device = device;
                device.Buffers.Add(this);
                Shape = shape;
                IsAllocated = true;
            }
        }


        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeBuffer(this);
            ptr = IntPtr.Zero;
        }

        public MemoryMapping CreateMemoryMapping(MemoryMapType type)
        {
            return type == MemoryMapType.Discard ? new MemoryMapping(this, true) : new MemoryMapping(this, false);
        }

        public MemoryView<T> CreateMemoryView<T>(MemoryMapType type) where T : unmanaged
        {
            return type == MemoryMapType.Discard ? new MemoryView<T>(new MemoryMapping(this, true)) :
                new MemoryView<T>(new MemoryMapping(this, false));
        }
    }
}
