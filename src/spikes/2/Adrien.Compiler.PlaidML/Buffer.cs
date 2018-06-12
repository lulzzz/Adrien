using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Buffer : PlaidMLApi<Buffer>
    {
        #region Constructors
        public Buffer(Context ctx, Device device, Shape shape) : base(ctx)
        {
            Size = plaidml.__Internal.PlaidmlGetShapeBufferSize(shape);
            if (Size == 0)
            {
                Error("plaidml_get_shape_buffer_size returned 0.");
                return;
            }
            ptr = plaidml.__Internal.PlaidmlAllocBuffer(context, device, Size);
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
        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeBuffer(this);
        }
        #endregion

        #region Properties
        public Device Device { get; protected set; }
        public Shape Shape { get; protected set; }
        public ulong Size { get; protected set; }
        #endregion

    }
}
