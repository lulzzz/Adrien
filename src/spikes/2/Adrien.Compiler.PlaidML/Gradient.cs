using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Gradient : Value
    {
        public Variable Variable { get; protected set; }


        public Gradient(Context ctx, Variable v) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocGradient(v);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_gradient");
                return;
            }
            else
            {
                Variable = v;
                IsAllocated = true;
            }
        }

        public Value ComputeWrt(Variable v)
        {
            ThrowIfNotAllocated();
            IntPtr g = plaidml.__Internal.PlaidmlComputeGradWrt(this, v);
            if (g.IsZero())
            {
                ReportApiCallError("plaidml_compute_grad_wrt");
                return null;
            }
            else
            {
                return new Value(this.Context, "GRAD" + Variable.Name, g);
            }
        }

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeGradient(this);
            ptr = IntPtr.Zero;
        }
    }
}
