using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Notation;

namespace Adrien.Compiler
{
    public class Var<T> : IVariable<T> where T : unmanaged
    {
        public Tensor Tensor { get; protected set; }

        public bool Initialized { get; protected set; }

        public string Name => Tensor.Name;

        public int[] Dimensions => Tensor.Dimensions;

        public int Rank => Tensor.Rank;

        public Memory<T> Memory { get; protected set; }

        public MemoryHandle Handle { get; protected set; }

        public DataType DataType => GetDataType();

        public int Stride { get; protected set; }

        public object Data { get; protected set; }

        public Span<T> Span => Memory.Span;


        
        internal Var(Tensor tensor)
        {
            Tensor = tensor;
        }


        internal Var(Tensor tensor, params T[] data)
        {
            if (tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements specified ({data.Length}) does not mach the number of elements in tensor {tensor.Label} : {tensor.NumberofElements}.");
            }

            Data = data;
            Memory = data.AsMemory();
            Handle = Memory.Pin();
            Initialized = true;
        }

        internal Var(Tensor tensor, Array array) : this(tensor)
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

            
            Data = array.Flatten<T>().ToArray();
            Memory = new Memory<T>((T[]) Data);
            Handle = Memory.Pin();
            Initialized = true;
        }


        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this.Read(index);
        }

        public static unsafe implicit operator IntPtr(Var<T> buffer)
        {
            return new IntPtr(buffer.Handle.Pointer);
        }

        internal Var(Tensor tensor, Memory<T> memory) : this(tensor)
        {
            Memory = memory;
            Handle = Memory.Pin();
            Initialized = true;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe ref T Read(int index)
        {
            ref T ret = ref Unsafe.Add(ref Unsafe.AsRef<T>(Handle.Pointer), index);
            return ref ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref C Read<C>(int index) where C : struct
        {
            //ref C ret = ref Unsafe.aAdd(ref Unsafe.AsRef<C>(_Ptr.ToPointer()), index);
            //return re
            return ref Unsafe.AsRef<C>(PtrTo(index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write<C>(int index, ref C value) where C : struct
        {
            Unsafe.Write(PtrTo(index), value);
        }

        public unsafe void* PtrTo(int index)
        {
            return Unsafe.Add<T>(Handle.Pointer, index);
        }

        internal void ThrowIfIndexOutOfRange(int index)
        {
            if (index >= Memory.Length)
            {
                throw new IndexOutOfRangeException($"Index {index} is greater than the maximum index of the memory buffer {Memory.Length - 1}.");
            }
            else if (index < 0)
            {
                throw new IndexOutOfRangeException($"Index {index} is less than zero.");
            }
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