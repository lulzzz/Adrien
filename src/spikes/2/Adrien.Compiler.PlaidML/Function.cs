using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Function : PlaidMLApi<Function>
    {
        public string Id { get; protected set; }
        public string Code { get; protected set; }

      
        public Function(Context ctx, string code) : base(ctx)
        {
            string id = "id_" + Guid.NewGuid().ToString("N");
            ptr = plaidml.__Internal.PlaidmlBuildCodedFunction(code, id);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_build_coded_function");
            }
            else
            {
                Id = id;
                Code = code;
                IsAllocated = true;
                Info("Added function Id:{0} Code={1}", Id, Code);
            }

        }
       
  
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeFunction(this);
            ptr = IntPtr.Zero;
        }
    }
}
