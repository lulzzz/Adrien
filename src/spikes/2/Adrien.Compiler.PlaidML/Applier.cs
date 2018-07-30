using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Applier : PlaidMLApi<Applier>
    {
        public Function Function { get; protected set; }

        public List<Value> Inputs { get; protected set; }

        public List<Value> Outputs { get; protected set; }

        public List<Applier> Dependencies { get; protected set; }

        public Applier(Context ctx, Function f) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocApplier(f);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_applier");
            }
            else
            {
                IsAllocated = true;
                Function = f;
                Inputs = new List<Value>();
                Outputs = new List<Value>();
            }
        }

        public bool AddInputValue(string name, IntPtr varPtr)
        {
            ThrowIfNotAllocated();
            Value i = new Value(this._Context, name, varPtr);
            if (i.IsAllocated)
            {
                return AddInputValue(name, i);
            }
            else
            {
                return false;
            }
        }

        public bool AddInputValue(Value i)
        {
            ThrowIfNotAllocated();
            if (!i.IsAllocated)
            {
                throw new ArgumentException("The input Placeholder is not allocated.");
            }
            bool r = plaidml.__Internal.PlaidmlApplyAddInput(this, i.Name, i);
            if (r)
            {
                Inputs.Add(i);
            }
            return r;
        }

        public bool AddInputValue(Variable iv)
        {
            ThrowIfNotAllocated();
            if (!iv.IsAllocated)
            {
                throw new ArgumentException("The input Variable is not allocated.");
            }
            return AddInputValue(new Value(iv));

        }

        public bool AddOutputValue(string name)
        {
            ThrowIfNotAllocated();
            IntPtr p = plaidml.__Internal.PlaidmlApplyAllocOutput(this, name);
            if (p.IsZero())
            {
                ReportApiCallError("plaidml_apply_alloc_output");
                return false;
            }
            else
            {
                Outputs.Add(new Value(this._Context, name, p));
                return true;
            }
        }

        public bool AddDependency(Applier dep)
        {
            ThrowIfNotAllocated();
            if (!dep.IsAllocated)
            {
                throw new ArgumentException("The dependency applier is not allocated.");
            }
            bool r = plaidml.__Internal.PlaidmlApplyAddDependency(this, dep);
            if (r)
            {
                Dependencies.Add(dep);
            }
            return r;
        }

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeApplier(this);
            ptr = IntPtr.Zero;
        }
    }
}
