using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class TensorVariable : Variable, IVariableShape
    {
        public Device Device { get; protected set; }

        public DeviceBuffer DeviceBuffer { get; protected set; }

        public Shape Shape { get; protected set; }

        public int Rank => Convert.ToInt32(Shape.DimensionCount);

        public int[] Dimensions => Shape.Dimensions.Select(d => Convert.ToInt32(d.length)).ToArray();

        public int[] Stride => Shape.Dimensions.Select(d => Convert.ToInt32(d.stride)).ToArray();

        public string Label => Name;

        public string Id { get; set; }

        public TensorVariable(Device device, Shape shape, string name, DeviceBuffer buffer = null) : base(device.Context, name)
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
                Name = name;
                Device = device;
                DeviceBuffer = buffer;
                Shape = shape;
                DataType = Shape.DataType;
                IsAllocated = true;
            }
        }
        

        public TensorVariableView<T> CreateView<T>(MemoryMapType mapType) 
            where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
        {
            ThrowIfNotAllocated();
            return new TensorVariableView<T>(this, mapType);
        }  

    }
}
