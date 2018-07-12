using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler;
using Adrien.Notation;

namespace Adrien
{
    public class Var<T> : IVariable<T>, IDisposable where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public Tensor Tensor { get; protected set; }

        public string Name => Tensor.Name;

        public int[] Dimensions => Tensor.Dimensions;

        public int Rank => Tensor.Rank;

        public int Stride { get; protected set; }

        public int ElementCount => Tensor.NumberofElements;

        public bool Initialized { get; protected set; }

        public MemoryHandle MemoryHandle { get; protected set; }

        public int Pins { get; protected set; }

        public bool IsPinned => Pins > 0;

        public unsafe Span<T> Span
        {
            get
            {
                ThrowIfNotInitialized();
                ThrowIfHandleIsNull();
                return new Span<T>(MemoryHandle.Pointer, Tensor.NumberofElements);
            }
        }

        
        internal Var(Tensor tensor)
        {
            Tensor = tensor;
        }

        internal Var(Tensor tensor, params T[] data)
        {
            if (data.Length ==0)
            {
                throw new ArgumentException($"Zero data elements specified.");
            }
            else if (tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements specified ({data.Length}) "
                    + $"does not mach the number of elements in tensor {tensor.Label} : {tensor.NumberofElements}.");
            }

            Tensor = tensor;
            MemoryHandle = new Memory<T>(data).Pin();
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
            
            MemoryHandle = new MemoryHandle(h.AddrOfPinnedObject().ToPointer(), h, this);
            Initialized = true;
        }

        internal Var(Tensor tensor, Memory<T> memory) : this(tensor)
        {
            MemoryHandle = memory.Pin();
            Initialized = true;
        }

        internal unsafe Var(Tensor tensor, MemoryHandle handle) : this(tensor)
        {
            MemoryHandle = handle;
            Initialized = true;
        }


        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                ThrowIfNotInitialized();
                ThrowIfHandleIsNull();
                ThrowIfIndexOutOfRange(index);
                return ref this.Read(index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref T Read(int index)
        {
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            ThrowIfIndexOutOfRange(index);
            return ref Read<T>(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref C Read<C>(int index) where C : unmanaged
        {
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            ThrowIfIndexOutOfRange(index);
            return ref Unsafe.AsRef<C>(PtrTo(index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write(int index, T value)
        {
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            ThrowIfIndexOutOfRange(index);
            Unsafe.Write(PtrTo(index), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write<C>(int index, C value) where C : unmanaged
        {
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            ThrowIfIndexOutOfRange(index);
            Unsafe.Write(PtrTo(index), value);
        }

        

        
        public static unsafe implicit operator IntPtr(Var<T> var)
        {
            var.ThrowIfNotInitialized();
            var.ThrowIfHandleIsNull();
            return new IntPtr(var.MemoryHandle.Pointer);
        }


        public void CopyFrom(params T[] data)
        {
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            ThrowIf1DArrayLengthIsNotTensorSize(data);
            Span<T> source = new Span<T>(data);
            bool r = source.TryCopyTo(this.Span);
            if (!r)
            {
                throw new Exception("Copy operation failed.");
            }
        }

        public void CopyTo(Span<T> destination)
        {
            ThrowIf1DArrayLengthIsNotTensorSize(destination);
            ThrowIfNotInitialized();
            ThrowIfHandleIsNull();
            bool r = this.Span.TryCopyTo(destination);
            if (!r)
            {
                throw new Exception("Copy operation failed.");
            }
        }

        public void CopyTo(T[] destination)
        {
            CopyTo(new Span<T>(destination));
        }

        public IVariable<T> Fill(T c)
        {
            this.Span.Fill(c);
            return this;
        }

        public MemoryHandle Pin(int elementIndex)
        {
            ThrowIfNotInitialized();
            Pins++;
            return MemoryHandle;
        }

        public void Unpin()
        {
            if (Pins == 0)
            {
                throw new InvalidOperationException("The memory for this variable is not pinned.");
            }
            Pins--;
        }


        #region INDArray implementation
        public int NDim => Rank;

        public int[] DeviceBufferShape => Dimensions;

        public Type DType => typeof(T);

        public int ItemSize => Unsafe.SizeOf<T>();

        public INDArray Zeros() => Fill(GenericMath<T>.Const(0));

        public INDArray Ones() => Fill(GenericMath<T>.Const(1));

        public INDArray Random()
        {
            for (int i = 0; i <= ElementCount; i++)
            {
                Write(i, GenericMath<T>.Random());
            }
            return this;
        }

        #endregion

        internal unsafe void* PtrTo(int index)
        {
            return Unsafe.Add<T>(MemoryHandle.Pointer, index);
        }

        internal void ThrowIfNotInitialized()
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("This variable is not initialized.");

            }
        }

        internal unsafe void ThrowIfHandleIsNull()
        {
            if (MemoryHandle.Pointer == null)
            {
                throw new InvalidOperationException("This memory handle pointer is null.");

            }
        }
        internal void ThrowIf1DArrayLenthIsNotTensorSize(Array data)
        {
            if (this.Tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements ({data.Length}) does not match " +
                    $"the number of elements in tensor {Tensor.Label} : {Tensor.NumberofElements}.");
            }
        }

        internal void ThrowIf1DArrayLengthIsNotTensorSize(params T[] data)
        {
            if (this.Tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements ({data.Length}) does not match " +
                    $"the number of elements in tensor {Tensor.Label} : {Tensor.NumberofElements}.");
            }
        }

        internal void ThrowIf1DArrayLengthIsNotTensorSize(Span<T> data)
        {
            if (this.Tensor.NumberofElements != data.Length)
            {
                throw new ArgumentException($"The number of data elements ({data.Length}) does not match " +
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

        internal void ThrowIfPinned()
        {
            if (IsPinned)
            {
                throw new InvalidOperationException("The memory for this variable is still pinned and cannot be freed.");
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                ThrowIfPinned();
                MemoryHandle.Dispose();
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