using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Function : PlaidMLApi<Function>
    {
        #region Constructors
        public Function(Context ctx, string code) : base(ctx)
        {
            string id = Guid.NewGuid().ToString();
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
            }

        }
        #endregion

        #region Overriden members
        public override void Free()
        {
            plaidml.__Internal.PlaidmlFreeFunction(this);
            base.Free();
        }
        #endregion

        #region Properties
        public string Id { get; protected set; }
        public string Code { get; protected set; }
        #endregion
    }
}
