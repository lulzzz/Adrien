using System;
using System.Collections.Generic;
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
            _ptr = plaidml.__Internal.PlaidmlAllocApplier(f);
            if (_ptr.IsZero())
            {
                // TODO: [vermorel] Probably throws an exception but unclear. I suggest to rename 'ThrowApiCallError`.
                // REMARK: [allisterb] ReportApiCallError only gets and logs the error by calling the native VaiLastStatus().
                ReportApiCallError("plaidml_alloc_applier");
                throw new PlaidMLApiException<Applier>(this, "Could not allocate applier.");
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
            var i = new Value(_context, name, varPtr);
            if (i.IsAllocated)
            {
                return AddInputValue(name, i);
            }

            return false;
        }

        public bool AddInputValue(Value i)
        {
            ThrowIfNotAllocated();
            if (!i.IsAllocated)
            {
                throw new ArgumentException("The input Value is not allocated.");
            }

            var r = plaidml.__Internal.PlaidmlApplyAddInput(this, i.Name, i);
            if (r)
            {
                Inputs.Add(i);
            }

            return r;
        }

        public Value AddOutputValue(string name)
        {
            ThrowIfNotAllocated();
            var p = plaidml.__Internal.PlaidmlApplyAllocOutput(this, name);
            if (p.IsZero())
            {
                ReportApiCallError("plaidml_apply_alloc_output");
                throw new PlaidMLApiException<Applier>(this, "Could not allocate output shape.");
                // TODO: [vermorel] Throw an exception instead, don't use 'null' to report faults.
                // REMARK: [allisterb] Throw PlaidMLApi exception on failure.
            }

            var o = new Value(_context, name, p);
            Outputs.Add(o);
            return o;
        }

        public bool AddDependency(Applier dep)
        {
            ThrowIfNotAllocated();
            if (!dep.IsAllocated)
            {
                throw new ArgumentException("The dependency applier is not allocated.");
            }

            var r = plaidml.__Internal.PlaidmlApplyAddDependency(this, dep);
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
            _ptr = IntPtr.Zero;
        }
    }
}