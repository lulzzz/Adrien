using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Tensor : Variable
    {
        public Device Device { get; protected set; }
        public DeviceBuffer Buffer { get; protected set; }
        public Shape Shape { get; protected set; }


        public Tensor(Device device, Shape shape, string name, DeviceBuffer buffer = null) : base(device.Context, name)
        {
            if (buffer == null)
            {
                buffer = device.CreateBuffer(shape);
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
                Shape = shape;
                DataType = Shape.DataType;
                IsAllocated = true;
            }
        }
        

        public MemoryView<T> CreateMemoryView<T>(bool discard = true) where T : unmanaged
        {
            ThrowIfNotAllocated();
            return new MemoryView<T>(new MemoryMapping(Buffer, discard));
        }

        public bool CopyFrom<T>(T[] array) where T : unmanaged
        {
            ThrowIfNotAllocated();
            MemoryView<T> v = CreateMemoryView<T>();
            return v.CopyFromAndFree(array);
        }
    }
}
