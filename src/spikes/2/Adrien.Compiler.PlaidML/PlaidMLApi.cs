using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public abstract class PlaidMLApi<T> : CompilerApi<T>, IDisposable
    {
        protected Context context;
        protected IntPtr ptr;

        
        public Context Context
        {
            get
            {
                ThrowIfNotAllocated();
                return context;
            }
        }
        public bool IsAllocated { get; protected set; } = false;
        public VaiStatus LastStatus { get; protected set; }
        public string LastStatusString { get; protected set; }
        public string ManualConfigText { get; protected set; }
        

        public PlaidMLApi(Context ctx) : base()
        {
            ctx.ThrowIfNotAllocated();
            this.context = ctx;
        }
        

        public static implicit operator IntPtr(PlaidMLApi<T> c)  
        {
            if (!c.IsAllocated)
            {
                throw new InvalidOperationException("This object is not allocated.");
            }
            else
            {
                return c.ptr;
            }
        }
        

        public virtual void Free()
        {
            ThrowIfNotAllocated();
            IsAllocated = false;
        }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ThrowIfNotAllocated()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This object is not allocated");
            }
        }

        [DebuggerStepThrough]
        protected void ReportApiCallError(string call) => Error("Call to {0} returned null or false. Status : {1} {2}", call,
            LastStatus = @base.VaiLastStatus(), LastStatusString = @base.VaiLastStatusStr());

        #region Disposer
        void IDisposable.Dispose()
        {
            ThrowIfNotAllocated();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            Free();
        }
        #endregion

    }
}
