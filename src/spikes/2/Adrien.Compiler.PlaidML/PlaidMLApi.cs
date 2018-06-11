using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public abstract class PlaidMLApi<T> : CompilerApi<T>, IDisposable
    {
        #region Constructors
        public PlaidMLApi(Context ctx, string manualConfigText = "") : base()
        {
            ctx.ThrowIfNotAllocated();
            this.context = ctx;
            ManualConfigText = manualConfigText;
            
        }
        #endregion

        #region Properties
        public bool IsAllocated { get; protected set; } = false;
        public VaiStatus LastStatus { get; protected set; }
        public string LastStatusString { get; protected set; }
        public string ManualConfigText { get; protected set; }

        public string Config
        {
            get
            {
                return ManualConfigText.IsNullOrEmpty() ? ManualConfigText : context.settings.ConfigFileText;
            }
        }
        #endregion

        #region Methods
        public virtual void Free()
        {
            ThrowIfNotAllocated();
            ptr = IntPtr.Zero;
            IsAllocated = false;
        }

        internal void ThrowIfNotAllocated()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This object is not allocated");
            }
        }

        protected void ReportApiCallError(string call) => Error("Call to {0} returned null or false. Status : {1} {2}", call,
            LastStatus = @base.VaiLastStatus(), LastStatusString = @base.VaiLastStatusStr());

        #region Disposer
        void IDisposable.Dispose()
        {
            ThrowIfNotAllocated();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private void Dispose(bool disposing)
        {
            Free();
        }

        #endregion

        #region Fields
        protected Context context;
        protected IntPtr ptr;
        #endregion

        #region Operators
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
        #endregion
    }
}
