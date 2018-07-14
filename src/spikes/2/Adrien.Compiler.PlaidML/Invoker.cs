using System;
using System.Collections.Generic;
using System.Linq;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invoker<T> : PlaidMLApi<Invoker<T>>, IRunnable<T> 
        where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public TensorVariable OutputTensorVariable { get; protected set; }

        public IReadOnlyList<TensorVariable> InputTensorVariables { get; protected set; }

        public bool InputVariablesSet { get; protected set; }

        public bool OutputVariablesSet { get; protected set; }

        public bool AllVariablesSet => InputVariablesSet && OutputVariablesSet;
        

        public Invoker(Context ctx, Function f, TensorVariable[] input, TensorVariable[] output) : base(ctx)
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
                InputTensorVariables = input;
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
        }

        public Invoker(Context ctx, Function f, TensorVariable output, params TensorVariable[] input)
            : this(ctx, f, input, new TensorVariable[] { output }) { }


        public bool Run(IEnumerable<IVariable<T>> input, IVariable<T> output)
        {
            ThrowIfNotAllocated();
            ThrowifAllVariablesNotSet();
            ThrowIfInputShapeMismatch(input);

            for(int i = 0; i < input.Count(); i++)
            {
                var iv = InputTensorVariables[i].CreateView<T>(MemoryMapType.Discard);
                if (!iv.CopyFromAndFree(input.ElementAt(i).Span))
                {
                    iv.Free();
                    return false;
                }
            }

            var c = Invoke();
            if (c.IsAllocated)
            {
                OutputTensorVariable.CreateView<T>(MemoryMapType.Retain).CopyToAndFree(output.Span);
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

        internal void ThrowIfInputShapeMismatch(IEnumerable<IVariable<T>> input)
        {
           for (int i = 0; i < InputTensorVariables.Count; i++)
           {
                var iv = InputTensorVariables[i];
                var id = input.ElementAt(i);

                if (!iv.Dimensions.SequenceEqual(id.Dimensions))
                {
                    throw new ArgumentException($"The dimensions of kernel input tensor {iv.Name} do not match the " +
                        $"dimensions of the input data variable {id.Name}.");
                }
                else if (iv.Rank != id.Rank)
                {
                    throw new ArgumentException($"The rank of kernel input tensor {iv.Name} does not match the " +
                        $"rank of the input data variable {id.Name}.");
                }
                else if (!iv.Stride.SequenceEqual(id.Stride))
                {
                    throw new ArgumentException($"The stride of kernel input tensor {iv.Name} does not match the " +
                        $"stride of the input data variable {id.Name}.");
                }

            }
        }
    }
}
