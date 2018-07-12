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

       
        public bool CopyFrom(T[] array)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            if (array.Length != this.ElementCount)
            {
                throw new ArgumentOutOfRangeException($"The length of the array {array.Length} does not match the length of the view {ElementCount}.");
            }
            Span<T> a = new Span<T>(array);
            a.CopyTo(Span);
            return Writeback();
        }

        public bool CopyFromAndFree(T[] array)
        {
            bool copy = CopyFrom(array);
            if (!copy)
            {
                return copy;
            }
            Free();
            return copy;
        }

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

        internal unsafe void* PtrTo(int index)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            ThrowIfIndexOutsideRange(index);
            return Unsafe.Add<T>(BaseAddress.ToPointer(), index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void ThrowIfIndexOutsideRange(int index)
        {
            if (index < 0 || index >= ElementCount)
            {
                throw new IndexOutOfRangeException();
            }
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
    }
}
