using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Context : PlaidMLApi<Context>
    {
        #region Constructors
        public Context(string logFileName)
        {            
            ptr = @base.__Internal.VaiAllocCtx();
            if (ptr.IsZero())
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

            if (@base.__Internal.VaiSetEventlog(ptr, logConfig))
            {
                Info($"PlaidML log file is {GetAssemblyDirectoryFullPath(logFileName)}.");
            }
            IsAllocated = true;
        }

        public Context() : this("PlaidML.log") {}
        #endregion

        #region Properties

        #endregion

        #region Overriden members
        public override void Free()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiFreeCtx(ptr);
            ptr = IntPtr.Zero;
            IsAllocated = false;
        }
        #endregion

        #region Methods
        public void Cancel()
        {
            ThrowIfNotAllocated();
            @base.__Internal.VaiCancelCtx(ptr);
        }
        #endregion

        #region Fields
        protected string logFileName;
        protected FileInfo logFile;
        #endregion
    }
}
