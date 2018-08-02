using System;
using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceBuffer : PlaidMLApi<DeviceBuffer>
    {
        public Device Device { get; protected set; }

        public Shape Shape { get; protected set; }

        public ulong SizeInBytes { get; protected set; }

        public DeviceBuffer(Context ctx, Device device, Shape shape) : base(ctx)
        {
            SizeInBytes = plaidml.__Internal.PlaidmlGetShapeBufferSize(shape);
            if (SizeInBytes == 0)
            {
                Error("plaidml_get_shape_buffer_size returned 0.");
                return;
            }

            _ptr = plaidml.__Internal.PlaidmlAllocBuffer(_context, device, SizeInBytes);
            if (_ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_buffer");
                // TODO: [vermorel] Don't return, throw an exception instead.
                return;
            }

            Device = device;
            device.Buffers.Add(this);
            Shape = shape;
            IsAllocated = true;
        }


        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeBuffer(this);
            _ptr = IntPtr.Zero;
        }
    }
}