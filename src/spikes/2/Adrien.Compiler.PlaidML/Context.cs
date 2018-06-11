using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Context : CompilerApi<Context>
    {
        #region Constructors
        public Context(string logFileName)
        {            
            ptr = @base.__Internal.VaiAllocCtx();
            if (ptr.IsZero())
            {
                IsAllocated = false;
                ReportApiCallError("vai_alloc_ctx");
                return;
            }

            Dictionary<string, string> _logConfig = new Dictionary<string, string>
            {

                {"@type", "type.vertex.ai/vertexai.eventing.file.proto.EventLog"},
                { "filename", logFileName }
            };
            string logConfig = JsonConvert.SerializeObject(_logConfig);

            if (@base.__Internal.VaiSetEventlog(ptr, logConfig))
            {
                Info($"PlaidML log file is {GetAssemblyDirectoryFullPath(logFileName)}.");
            }
            IsAllocated = true;
        }

        public Context() : this("PlaidML.log") {}
        #endregion

        #region Properties
        public bool IsAllocated { get; protected set; }
        public VaiStatus LastStatus { get; protected set; }
        public string LastStatusString { get; protected set; }
        #endregion

        #region Methods
        public void Free()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiFreeCtx(ptr);
            ptr = IntPtr.Zero;
            IsAllocated = false;
        }
        
        public void Cancel()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiCancelCtx(ptr);
        }

        internal void ThrowIfNotAllocated()
        {
            if (!IsAllocated)
            {
                throw new InvalidOperationException($"This context is not allocated");
            }
        }

        protected void ReportApiCallError(string call) => Error("Call to {0} returned null or false. Status : {1} {2}", call,
            LastStatus = @base.VaiLastStatus(), LastStatusString = @base.VaiLastStatusStr());
        #endregion

        #region Fields
        protected IntPtr ptr;
        protected string logFileName;
        protected FileInfo logFile;
        #endregion

        #region Operators
        public static implicit operator IntPtr(Context c)
        {
            if (!c.IsAllocated)
            {
                throw new InvalidOperationException("This context is not allocated.");
            }
            else
            {
                return c.ptr;
            }
        }
        #endregion

    }
}
