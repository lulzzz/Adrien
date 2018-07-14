using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Text;

namespace Adrien.Compiler.PlaidML
{
    public class TensorVariableView<T> : MemoryMapping, IVariable<T> 
        where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public TensorVariable TensorVariable
        {
            get
            {
                ThrowIfNotAllocated();
                ThrowIfNotValid();
                return _TensorVariable;
            }
        }

        public DeviceBuffer DeviceBuffer => TensorVariable.DeviceBuffer;

        public string Name => TensorVariable.Name;

        public int ElementCount => (int) DeviceBuffer.Shape.ElementCount;

        public int[] Dimensions => TensorVariable.Shape.Dimensions.Select(d => Convert.ToInt32(d.length)).ToArray();

        public int[] Stride => TensorVariable.Shape.Dimensions.Select(d => Convert.ToInt32(d.stride)).ToArray();

        public int Rank => Convert.ToInt32(TensorVariable.Shape.DimensionCount);

        public Span<T> Span => GetSpan<T>();

        public bool IsDirty { get; protected set; }

        protected TensorVariable _TensorVariable;


        public TensorVariableView(TensorVariable variable, MemoryMapType mapType) 
            : base(variable.DeviceBuffer, mapType == MemoryMapType.Discard ? true : false)
        {
            _TensorVariable = variable;
        }

        
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                ThrowIfNotAllocated();
                ThrowIfNotValid();
                return ref Read(index);
            }
        }
        
        public override bool Writeback()
        {
            if (base.Writeback())
            {
                IsDirty = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CopyFromAndFree(Span<T> src)
        {
            bool copy = CopyFrom(src);
            if (copy)
            {
                Free();
            }
            return copy;
        }

        public bool CopyFromAndFree(T[] array) => CopyFromAndFree(new Span<T>(array));

        public bool CopyToAndFree(Span<T> dest)
        {
            bool copy = CopyTo(dest);
            if (copy)
            {
                Free();
            }
            return copy;
        }

        public bool CopyToAndFree(T[] array) => CopyToAndFree(new Span<T>(array));


        #region INDArray implementation
        public bool Initialized => IsAllocated;

        public int NDim => Convert.ToInt32(DeviceBuffer.Shape.DimensionCount);

        public int[] DeviceBufferShape => DeviceBuffer.Shape.Dimensions
            .Select(d => Convert.ToInt32(d.length)).ToArray();


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

        public IVariable<T> Fill(T c)
        {
            this.Span.Fill(c);
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref T Read(int index)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            ThrowIfIndexOutsideRange(index);
            return ref Unsafe.Add(ref Unsafe.AsRef<T>(BaseAddress.ToPointer()), index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Write(int index, T value)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            ThrowIfIndexOutsideRange(index);
            ref T v = ref Unsafe.Add(ref Unsafe.AsRef<T>(BaseAddress.ToPointer()), index);
            v = value;
            IsDirty = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe void* PtrTo(int index)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            ThrowIfIndexOutsideRange(index);
            return Unsafe.Add<T>(BaseAddress.ToPointer(), index);
        }

        protected bool CopyFrom(Span<T> src)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            if (src.Length != this.ElementCount)
            {
                throw new ArgumentOutOfRangeException($"The length of the source span: {src.Length} " + 
                    $"does not match the length of the view {ElementCount}.");
            }
            bool r = src.TryCopyTo(Span);
            if (r)
            {
                return Writeback();
            }
            else return false;
        }

        protected bool CopyTo(Span<T> dest)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            if (dest.Length != this.ElementCount)
            {
                throw new ArgumentOutOfRangeException($"The length of the source span: {dest.Length} " +
                    $"does not match the length of the view {ElementCount}.");
            }
            return Span.TryCopyTo(dest);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void ThrowIfIndexOutsideRange(int index)
        {
            if (index < 0 || index >= ElementCount)
            {
                throw new IndexOutOfRangeException();
            }
        }

 
    }
}
