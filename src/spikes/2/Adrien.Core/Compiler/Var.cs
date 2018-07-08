using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Notation;

namespace Adrien.Compiler
{
    public class Var<T> : IVariable<T>, INDArray<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public Tensor Tensor { get; protected set; }

        public string Name => Tensor.Name;

        public int[] Dimensions => Tensor.Dimensions;

        public int Rank => Tensor.Rank;

        public int Size => Tensor.NumberofElements;

        public bool Initialized { get; protected set; }

        public MemoryHandle Handle { get; protected set; }

        public int Stride { get; protected set; }

        public object Data { get; protected set; }

        public unsafe Span<T> Span => new Span<T>(Handle.Pointer, Tensor.NumberofElements);


        
        internal Var(Tensor tensor)
        {
            Tensor = tensor;
        }

        internal Var(Tensor tensor, params T[] data)
        {
            if (tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements specified ({data.Length}) "
                    + $"does not mach the number of elements in tensor {tensor.Label} : {tensor.NumberofElements}.");
            }
            Tensor = tensor;
            Memory<T> m = new Memory<T>(data);
            Handle = m.Pin();
            Initialized = true;
        }

        internal unsafe Var(Tensor tensor, Array array) : this(tensor)
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
                int dim = array.GetLowerBound(i) == 0 ? array.GetUpperBound(i) + 1 : 
                    array.GetUpperBound(i) - array.GetLowerBound(i);
                if ( dim != tensor.Dimensions[i])
                {
                    throw new ArgumentException($"The array dimension {i} has size {dim} but tensor dimension {i} " + 
                        $"has size {tensor.Dimensions[i]}.");
                }
            }
          
            GCHandle h = GCHandle.Alloc(array, GCHandleType.Pinned);
            if (!h.IsAllocated)
            {
                throw new Exception("Could not allocate GCHandle for array.");
            }
            
            Handle = new MemoryHandle(h.AddrOfPinnedObject().ToPointer(), h);
            Initialized = true;
        }

        internal Var(Tensor tensor, Memory<T> memory) : this(tensor)
        {
            Handle = memory.Pin();
            Initialized = true;
        }

        internal Var(Tensor tensor, MemoryHandle handle) : this(tensor)
        {
            Handle = handle;
            Initialized = true;
        }


        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                ThrowIfIndexOutOfRange(index);
                return ref this.Read(index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref T Read(int index)
        {
            // return ref Unsafe.Add(ref Unsafe.AsRef<T>(Handle.Pointer), index);
            return ref Read<T>(index); 
            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write(int index, T value)
        {
            Unsafe.Write(PtrTo(index), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write<C>(int index, C value) where C : unmanaged
        {
            Unsafe.Write(PtrTo(index), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref C Read<C> (int index) where C : unmanaged
        {
            return ref Unsafe.AsRef<C>(PtrTo(index));
        }

        public static unsafe implicit operator IntPtr(Var<T> buffer)
        {
            return new IntPtr(buffer.Handle.Pointer);
        }


        public void CopyFrom(params T[] data)
        {
            ThrowIf1DArrayLenthIsNotTensorSize(data);
            Span<T> source = new Span<T>(data);
            bool r = source.TryCopyTo(this.Span);
            if (!r)
            {
                throw new Exception("Copy operation failed.");
            }
        }

        internal unsafe void* PtrTo(int index)
        {
            return Unsafe.Add<T>(Handle.Pointer, index);
        }


        internal void ThrowIf1DArrayLenthIsNotTensorSize(params T[] data)
        {
            if (this.Tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements specified ({data.Length}) does not match " +
                    $"the number of elements in tensor {Tensor.Label} : {Tensor.NumberofElements}.");
            }
        }

        internal void ThrowIf1DArrayLenthIsNotTensorSize(Array data)
        {
            if (this.Tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements specified ({data.Length}) does not match " +
                    $"the number of elements in tensor {Tensor.Label} : {Tensor.NumberofElements}.");
            }
        }

        internal void ThrowIfIndexOutOfRange(int index)
        {
            if (index >= Tensor.NumberofElements)
            {
                throw new IndexOutOfRangeException($"Index {index} is greater than the maximum index of the memory " +
                    $"buffer {Tensor.NumberofElements - 1}.");
            }
            else if (index < 0)
            {
                throw new IndexOutOfRangeException($"Index {index} is less than zero.");
            }
        }

        #region INDArray implementation
        public int NDim => Rank;

        public int[] Shape => Dimensions;

        public Type DType => typeof(T);

        public int ItemSize => Unsafe.SizeOf<T>();


        public IVariable<T> Zeros()
        {
            this.Span.Fill(GM<T>.Const(0));
            return this;
        }

        
        public IVariable<T> Ones()
        {
            this.Span.Fill(GM<T>.Const(1));
            return this;
        }

        public IVariable<T> Random()
        {
            for (int i = 0; i <= Size; i++)
            {
                Write(i, GM<T>.Random());
            }
            return this;
        }

        #endregion

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