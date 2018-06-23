﻿using System;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invoker : PlaidMLApi<Invoker>
    {
        public bool InputVariablesSet { get; protected set; }
        public bool OutputVariablesSet { get; protected set; }
        public bool AllVariablesSet => InputVariablesSet && OutputVariablesSet;
        
        public Invoker(Context ctx, Function f, params Variable[] inputs) : base(ctx)
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
            for (int i = 0; i < inputs.Length; i++)
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
                InputVariablesSet = true;
            }
            else
            {
                InputVariablesSet = false;
                return;
            }

        }

        public Invoker(Context ctx, Function f, Variable[] inputs, Variable[] outputs) : base(ctx)
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
            for (int i = 0; i < inputs.Length; i++)
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
                InputVariablesSet = true;
            }
            else
            {
                InputVariablesSet = false;
                return;
            }

            for (int i = 0; i < outputs.Length; i++)
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
                OutputVariablesSet = true;
            }
            else
            {
                OutputVariablesSet = false;
                return;
            }
            
        }
        
        
        public Shape GetOutputShape(string outputVariableName)
        {
            ThrowIfNotAllocated();
            ThrowifInputVariablesNotSet();
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

        public bool SetInvokerOutoutVariables(params Variable[] outputs)
        {
            bool r = false;
            for (int i = 0; i < outputs.Length; i++)
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
                OutputVariablesSet = true;
            }
            else
            {
                OutputVariablesSet = false;
            }
            return r;
        }

        public Invocation Invoke()
        {
            return new Invocation(context, this);
        }

        internal void ThrowifInputVariablesNotSet()
        {
            if (!InputVariablesSet)
            {
                throw new InvalidOperationException("Input variables are not allocated.");
            }
        }

        internal void ThrowifAllVariablesNotSet()
        {
            if (!AllVariablesSet)
            {
                throw new InvalidOperationException("All variables are not allocated.");
            }
        }
    }
}