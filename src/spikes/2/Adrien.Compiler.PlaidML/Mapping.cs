using System;
using System.Collections.Generic;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Mapping : PlaidMLApi<Mapping>
    {
        #region Constructors
        public Mapping(DeviceBuffer buffer, bool discard = false) : base(buffer.Context)
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
            }
        }
        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeMapping(this);
        }
        #endregion

        #region Properties
        public DeviceBuffer Buffer { get; protected set; }

        public IntPtr BaseAddress
        {
            get
            {
                ThrowIfNotAllocated();
                unsafe
                {
                    void *_r = plaidml.__Internal.PlaidmlGetMappingBase(context, this);
                    return new IntPtr(_r);
                }
            }
        }

        public ulong SizeInBytes
        {
            get
            {
                ThrowIfNotAllocated();
                return plaidml.__Internal.PlaidmlGetMappingSize(context, this);
            }
        }
        #endregion

        #region Methods
        public bool Writeback()
        {
            ThrowIfNotAllocated();
            bool r = plaidml.__Internal.PlaidmlWritebackMapping(context, this);
            if (!r)
            {
                ReportApiCallError("plaidml_writeback_mapping");
            }
            return r;
        }

        public unsafe Span<T> GetSpan<T>() where T : unmanaged
        {
            return new Span<T>(BaseAddress.ToPointer(), (int)(SizeInBytes / (ulong)sizeof(T)));
        }
        #endregion
    }
}
