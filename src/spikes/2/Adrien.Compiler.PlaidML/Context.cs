using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Context :IDisposable
    {
        #region Constructors
        public Context(string logFileName)
        {            
            ctxPtr = @base.__Internal.VaiAllocCtx();
            if (ctxPtr.IsZero())
            {
                IsAllocated = false;
                return;
            }

            Dictionary<string, string> _logConfig = new Dictionary<string, string>
            {

                {"@type", "type.vertex.ai/vertexai.eventing.file.proto.EventLog"},
                { "filename", logFileName }
            };
            string logConfig = JsonConvert.SerializeObject(_logConfig);

            bool r = @base.__Internal.VaiSetEventlog(ctxPtr, logConfig);
            IsAllocated = true;
        }

        public Context() : this("PlaidML.log") {}
        #endregion

        #region Properties
        public bool IsAllocated { get; protected set; }
        #endregion

        #region Methods
        public void Free()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiFreeCtx(ctxPtr);
            ctxPtr = IntPtr.Zero;
            IsAllocated = false;
        }

        public void Cancel()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiCancelCtx(ctxPtr);
        }
        
        protected void ThrowIfNotAllocated()
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

        #region Operators
        public static implicit operator IntPtr(Context c)  // explicit byte to digit conversion operator
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
        protected string logFileName;
        protected FileInfo logFile;
        #endregion
    }
}
