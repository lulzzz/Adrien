using System;
using System.Collections.Generic;
using System.Linq;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invoker<T> : PlaidMLApi<Invoker<T>>, IRunnable<T> 
        where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public IReadOnlyList<TensorVariable> OutputTensors { get; protected set; }

        public IReadOnlyList<TensorVariable> InputTensors { get; protected set; }

        public bool InputVariablesSet { get; protected set; }

        public bool OutputVariablesSet { get; protected set; }

        public bool AllVariablesSet => InputVariablesSet && OutputVariablesSet;
        
        public IReadOnlyList<IVariable<T>> Input { get; protected set; }

        public IReadOnlyList<IVariable<T>> Output { get; protected set; }


        public Invoker(Context ctx, Function f, Variable[] input, Variable[] output) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocInvoker(_Context, f); 
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
            for (int i = 0; i < input.Length; i++)
            {
                r = plaidml.__Internal.PlaidmlSetInvokerInput(this, input[i].Name, input[i]);
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

            for (int i = 0; i < output.Length; i++)
            {
                r = plaidml.__Internal.PlaidmlSetInvokerOutput(this, output[i].Name, output[i]);
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

            if (AllVariablesSet)
            {
                Input = InputTensors.Select(t => t.CreateView<T>(MemoryMapType.Discard)).ToList();
            }
            
        }

        public Invoker(Context ctx, Function f, Variable output, params Variable[] input)
            : this(ctx, f, input, new Variable[] { output }) { }


        public bool Run()
        {
            ThrowIfNotAllocated();
            ThrowifAllVariablesNotSet();

            foreach (var v in Input)
            {
                var tv = (TensorVariableView<T>) v;
                if (!tv.Writeback())
                {
                    return false;
                }
            }

            foreach (var v in Output)
            {
                var tv = (TensorVariableView<T>) v;
                if (!tv.Writeback())
                {
                    return false;
                }
            }

            var c = this.Invoke();
            if (c.IsAllocated)
            {
                Input = InputTensors.Select(t => t.CreateView<T>(MemoryMapType.Retain)).ToList();
                Output = OutputTensors.Select(t => t.CreateView<T>(MemoryMapType.Retain)).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Invocation<T> Invoke()
        {
            ThrowIfNotAllocated();
            ThrowifAllVariablesNotSet();
            return new Invocation<T>(_Context, this);
        }

        public Shape GetOutputShape(string outputVariableName)
        {
            ThrowIfNotAllocated();
            ThrowIfNotAllocated();
            IntPtr r = plaidml.__Internal.PlaidmlAllocInvokerOutputShape(this, outputVariableName);
            if (r.IsZero())
            {
                ReportApiCallError("plaidml_alloc_invoker_output_shape");
                return null;
            }
            else
            {
                return new Shape(this._Context, r);
            }

        }

        protected bool SetInvokerOutoutVariables(params Variable[] outputs)
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
