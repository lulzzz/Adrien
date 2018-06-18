using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Text;

namespace Adrien.Compiler.PlaidML
{
    public class MemoryView<T> : PlaidMLApi<MemoryView<T>> where T : unmanaged
    {
        public MemoryMapping Mapping { get; protected set; }

        public DeviceBuffer Buffer => Mapping.Buffer;

        public Shape Shape => Buffer.Shape;

        public IntPtr BaseAddress => Mapping.BaseAddress;

        public int Length => (int)Shape.ElementCount;

        public Span<T> Span => Mapping.GetSpan<T>();

        public bool IsDirty { get; protected set; }
        

        public MemoryView(MemoryMapping mapping) : base(mapping.Context)
        {
            Mapping = mapping;
            IsAllocated = mapping.IsAllocated;
        }

        
        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return Read(index);
            }
            set
            {
                Write(index, value);
            }
        }
        
        
        public override void Free() => Mapping.Free();
        
        public bool Writeback()
        {
            if (Mapping.Writeback())
            {
                IsDirty = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WritebackandFree()
        {
            Writeback();
            Free();
        }
        public bool CopyFrom(T[] array)
        {
            ThrowIfNotValid();
            if (array.Length != this.Length)
            {
                throw new ArgumentOutOfRangeException($"The length of the array {array.Length} does not match the length of the view {Length}.");
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

        protected void ThrowIfNotValid() => Mapping.ThrowIfNotValid();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void ThrowIfIndexOutsideRange(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected unsafe ref T Read(int index)
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            ThrowIfIndexOutsideRange(index);
            return ref Unsafe.Add(ref Unsafe.AsRef<T>(BaseAddress.ToPointer()), index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected unsafe void Write(int index, T value)
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
