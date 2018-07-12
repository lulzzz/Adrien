using System;
using System.Buffers;
using System.Collections.Generic;


using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class DeviceTensor : Variable
    {
        public Device Device { get; protected set; }

        public DeviceBuffer TensorBuffer { get; protected set; }

        public Shape Shape { get; protected set; }

        public MemoryMapping MemoryMapping { get; protected set; }
        
        public bool IsMemoryMapped { get; protected set; }

        public DeviceTensor(Device device, Shape shape, string name, DeviceBuffer buffer = null) : base(device.Context, name)
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

            ptr = plaidml.__Internal.PlaidmlAllocTensor(_Context, buffer, shape);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_tensor");
                return;
            }
            else
            {
                Device = device;
                TensorBuffer = buffer;
                Shape = shape;
                DataType = Shape.DataType;
                IsAllocated = true;
            }
        }
        

        public MemoryView<T> CreateView<T>(MemoryMapType mapType) where T : unmanaged
        {
            ThrowIfNotAllocated();
            return TensorBuffer.CreateMemoryView<T>(mapType);
        }
        
    }
}
