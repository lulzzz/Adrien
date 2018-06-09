using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler.PlaidML
{
    public abstract class PlaidMLApi<T> : CompilerApi<T>, IDisposable
    {
        #region Properties
        public bool IsAllocated { get; protected set; }
        #endregion

        #region Methods
        public abstract void Free();
        internal void ThrowIfNotAllocated()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This context is not allocated");
            }
        }
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
