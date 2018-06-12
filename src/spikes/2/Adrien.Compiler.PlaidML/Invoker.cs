using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invoker : PlaidMLApi<Invoker>
    {
        #region Constructors
        public Invoker(Context ctx, Function f, List<Variable> inputs, List<Variable> outputs) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocInvoker(context, f); 
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_invoker");
                return;
            }
            else
            {
                IsAllocated = true;
            }

            bool r = false;
            for (int i = 0; i < inputs.Count; i++)
            {
                r = plaidml.__Internal.PlaidmlSetInvokerInput(this, inputs[i].Name, inputs[i]);
                if (!r)
                {
                    ReportApiCallError("plaidml_set_invoker_input");
                    break;
                }
            }
            if (r)
            {
                AllInputVariablesAllocated = true;
            }
            else
            {
                AllInputVariablesAllocated = false;
                return;
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                r = plaidml.__Internal.PlaidmlSetInvokerOutput(this, outputs[i].Name, outputs[i]);
                if (!r)
                {
                    ReportApiCallError("plaidml_set_invoker_output");
                    break;
                }
            }
            if (r)
            {
                AllOutputVariablesAllocated = true;
            }
            else
            {
                AllOutputVariablesAllocated = false;
                return;
            }
            if (AllInputVariablesAllocated && AllOutputVariablesAllocated)
            {

            }
        }
        #endregion

        #region Properties
        public bool AllInputVariablesAllocated { get; protected set; }
        public bool AllOutputVariablesAllocated { get; protected set; }
        public bool AllVariablesAllocated => AllInputVariablesAllocated && AllOutputVariablesAllocated;
        #endregion

        #region Methods
        public Shape GetOutputShape(string outputVariableName)
        {
            ThrowIfNotAllocated();
            ThrowifAllVariablesNotAllocated();
            IntPtr r = plaidml.__Internal.PlaidmlAllocInvokerOutputShape(this, outputVariableName);
            if (r.IsZero())
            {
                ReportApiCallError("plaidml_alloc_invoker_output_shape");
                return null;
            }
            else
            {
                return new Shape(this.context, r);
            }

        }
        internal void ThrowifAllVariablesNotAllocated()
        {
            if (!AllVariablesAllocated)
            {
                throw new InvalidOperationException("All variables are not allocated.");
            }
        }
        #endregion
    }
}
