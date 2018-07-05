using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;

namespace Adrien.Compiler
{
    public class Var<T> : IVariable<T> where T : unmanaged
    {
        public Tensor Tensor { get; protected set; }

        public Memory<T> Memory { get; protected set; }

        public bool Initialized { get; protected set; }

        public string Name => Tensor.Name;

        public int[] Dimensions => Tensor.Dimensions;

        public int Rank => Tensor.Rank;

        public DataType DataType => GetDataType();

        public int Stride { get; protected set; }

        public object Data { get; protected set; }

        public Var(Tensor tensor)
        {
            Tensor = tensor;
        }

        public Var(Tensor tensor, Array array) : this(tensor)
        {
            int[] zeroindex = new int[array.Rank];
            object zeroelement = array.GetValue(zeroindex);
            if (!(zeroelement is T))
            {
                throw new ArgumentException($"The array must have type {typeof(T).Name} to initialize this variable.");
            }
            if (array.Rank != tensor.Rank)
            {
                throw new ArgumentException($"The array rank is {array.Rank} but the tensor rank is {tensor.Rank}.");
            }
            for (int i = 0; i < array.Rank; i++)
            {
                int dim = array.GetLowerBound(i) == 0 ? array.GetUpperBound(i) + 1 : array.GetUpperBound(i) - array.GetLowerBound(i);
                if ( dim != tensor.Dimensions[i])
                {
                    throw new ArgumentException($"The array dimension {i} has size {dim} but tensor dimension {i} has size {tensor.Dimensions[i]}.");
                }
            }

            Data = array;
            Initialized = true;
        }

        public static DataType GetDataType()
        {
            T t = default;
            switch (t)
            {
                case Boolean _:
                    return DataType.BOOLEAN;
                   
                case SByte _:
                    return DataType.INT8;

                case Byte _:
                    return DataType.UINT8;

                case Int16 _:
                    return DataType.INT16;

                case UInt16 _:
                    return DataType.UINT16;

                case Int32 _:
                    return DataType.INT32;

                case UInt32 _:
                    return DataType.UINT32;

                case Int64 _:
                    return DataType.INT64;

                case UInt64 _:
                    return DataType.UINT64;

                case Single _:
                    return DataType.FLOAT32;

                case Double _:
                    return DataType.FLOAT64;

                default:
                    throw new NotSupportedException($"Unsupported .NET type:{typeof(T).Name}");
            }
            
        }
    }
}