using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invocation : PlaidMLApi<Invocation>
    {
        #region Constructors
        public Invocation(Context ctx, Invoker invoker) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlScheduleInvocation(context, invoker);
            if(ptr.IsZero())
            {
                ReportApiCallError("plaidml_schedule_invocation");
                return;
            }
            else
            {
                Invoker = invoker;
                IsAllocated = true;

            }
        }
        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeInvocation(this);
        }
        #endregion

        #region Properties
        public Invoker Invoker { get; protected set; }
        #endregion
    }
}
