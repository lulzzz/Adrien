using System;
using System.Collections.Generic;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class MemoryMapping : PlaidMLApi<MemoryMapping>
    {
        public DeviceBuffer Buffer { get; protected set; }

        public IntPtr BaseAddress
        {
            get
            {
                ThrowIfNotAllocated();
                ThrowIfNotValid();
                unsafe
                {
                    void *_r = plaidml.__Internal.PlaidmlGetMappingBase(_Context, this);
                    return new IntPtr(_r);
                }
            }
        }

        public ulong SizeInBytes
        {
            get
            {
                ThrowIfNotAllocated();
                ThrowIfNotValid();
                return plaidml.__Internal.PlaidmlGetMappingSize(_Context, this);
            }
        }

        public bool IsValid { get; protected set; }

        
        public MemoryMapping(DeviceBuffer buffer, bool discard = true) : base(buffer.Context)
        {
            if (discard)
            {
                ptr = plaidml.__Internal.PlaidmlMapBufferDiscard(buffer.Context, buffer);
            }
            else
            {
                ptr = plaidml.__Internal.PlaidmlMapBufferCurrent(buffer, IntPtr.Zero, IntPtr.Zero);
            }
            if (ptr.IsZero())
            {
                ReportApiCallError(discard ? "plaidml_map_buffer_discard" : "plaidml_map_buffer_current");
                return;
            }
            else
            {
                Buffer = buffer;
                IsAllocated = true;
                IsValid = true;
            }
        }

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeMapping(this.ptr);
            ptr = IntPtr.Zero;
        }
        
        public bool Writeback()
        {
            ThrowIfNotAllocated();
            ThrowIfNotValid();
            bool r = plaidml.__Internal.PlaidmlWritebackMapping(_Context, this);
            if (!r)
            {
                ReportApiCallError("plaidml_writeback_mapping");
            }
            else
            {
                Invalidate();
            }
            return r;
        }

        public unsafe Span<T> GetSpan<T>() where T : unmanaged
        {
            ThrowIfNotValid();
            return new Span<T>(BaseAddress.ToPointer(), (int)(SizeInBytes / (ulong)sizeof(T)));
        }

        internal void ThrowIfNotValid()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("This mapping has been invalidated.");
            }
        }

        protected void Invalidate()
        {
            IsValid = false;
        }
    }
}
