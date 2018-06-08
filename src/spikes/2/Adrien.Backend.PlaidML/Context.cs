using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Backend.PlaidML.Bindings;

namespace Adrien.Backend.PlaidML
{
    public class Context :IDisposable
    {
        #region Constructors
        public Context()
        {
            ctxPtr = @base.__Internal.VaiAllocCtx();
            if (!ctxPtr.IsZero())
            {
                IsAllocated = true;
            }
            else
            {
                IsAllocated = false;
            }
           
        }
        #endregion

        #region Properties
        public bool IsAllocated { get; protected set; }
        #endregion

        #region Methods
        public void Free()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This context is not allocated");
            }
            @base.__Internal.VaiAllocCtx();
            IsAllocated = false;
        }
        

        #region Disposer
        void IDisposable.Dispose()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This context is not allocated");
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private void Dispose(bool disposing)
        {
            Free();
        }

        #endregion

        #region Operators
        public static explicit operator IntPtr(Context c)  // explicit byte to digit conversion operator
        {
            if (!c.IsAllocated)
            {
                throw new InvalidOperationException("This context is not allocated.");
            }
            else
            {
                return c.ctxPtr;
            }
        }
        #endregion

        #region Fields
        protected IntPtr ctxPtr;
        #endregion
    }
}
