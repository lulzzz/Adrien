using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invocation<T> : PlaidMLApi<Invocation<T>>
        where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public Invoker<T> Invoker { get; protected set; }
       
        public Invocation(Context ctx, Invoker<T> invoker) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlScheduleInvocation(_Context, invoker);
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
        

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeInvocation(this);
            ptr = IntPtr.Zero;
        }
    }
}
