using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Invoker<T> : PlaidMLApi<Invoker<T>>, IRunnable<T> 
        where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public DeviceTensor OutputTensor { get; protected set; }

        public IReadOnlyList<DeviceTensor> InputTensors { get; protected set; }

        public IDictionary<DeviceTensor, DeviceTensor> Gradients { get; protected set; }

        public bool InputTensorsSet { get; protected set; }

        public bool OutputTensorsSet { get; protected set; }

        

        public bool AllVariablesSet => InputTensorsSet && OutputTensorsSet;

       
        public string RunStatusMessage { get; protected set; }

        public Invoker(Context ctx, Function f, DeviceTensor[] input, DeviceTensor[] output) : base(ctx)
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
                InputTensorsSet = true;
                InputTensors = input;
            }
            else
            {
                InputTensorsSet = false;
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
                OutputTensorsSet = true;
                OutputTensor = output[0];
            }
            else
            {
                OutputTensorsSet = false;
                return;
            }
        }

        public Invoker(Context ctx, Function f, DeviceTensor output, params DeviceTensor[] input)
            : this(ctx, f, input, new DeviceTensor[] { output }) { }


        public RunStatus Run(IVariable<T> output, params IVariable<T>[] input)
        {
            ThrowIfNotAllocated();
            ThrowifAllVariablesNotSet();
            ThrowIfInputShapeMismatch(input);

            for(int i = 0; i < input.Count(); i++)
            {
                var iv = InputTensors[i].CreateView<T>(MemoryMapType.Discard);
                if (!iv.CopyFromAndFree(input.ElementAt(i).Span))
                {
                    iv.Free();
                    RunStatusMessage = $"Could not copy data from input variable {input.ElementAt(i).Name} to " + 
                        $"device tensor {iv.Name}.";
                    return RunStatus.ErrorAllocatingInput;
                }
            }

            var c = Invoke();
            if (c.IsAllocated)
            {
                if (OutputTensor.CreateView<T>(MemoryMapType.Retain).CopyToAndFree(output.Span))
                {
                    Gradients = new Dictionary<DeviceTensor, DeviceTensor>();
                    for (int i = 0; i < InputTensors.Count; i++)
                    {
                        Gradient gc = new Gradient(Context, OutputTensor);
                        if (!gc.IsAllocated) continue;
                        IntPtr g = gc.ComputeWrt(InputTensors[i]);
                        if (g.IsZero()) continue;
                        DeviceTensor grad = new DeviceTensor(g, "O" + i, InputTensors[i]);
                        Gradients.Add(InputTensors[i], grad);
                    }
                    return RunStatus.Success;
                }
                else
                {
                    RunStatusMessage = c.LastStatusString;
                    return RunStatus.ErrorExecuting;
                }
            }
            else
            {
                RunStatusMessage = c.LastStatusString;
                return RunStatus.ErrorExecuting;
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
                OutputTensorsSet = true;
            }
            else
            {
                OutputTensorsSet = false;
            }
            return r;
        }

        [DebuggerStepThrough]
        internal void ThrowifInputVariablesNotSet()
        {
            if (!InputTensorsSet)
            {
                throw new InvalidOperationException("Input variables are not allocated.");
            }
        }

        [DebuggerStepThrough]
        internal void ThrowifAllVariablesNotSet()
        {
            if (!AllVariablesSet)
            {
                throw new InvalidOperationException("All variables are not allocated.");
            }
        }

        [DebuggerStepThrough]
        internal void ThrowIfInputShapeMismatch(IEnumerable<IVariable<T>> input)
        {
           for (int i = 0; i < InputTensors.Count; i++)
           {
                var iv = InputTensors[i];
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
