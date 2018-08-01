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

        public Applier Applier { get; protected set; }

        public Value OutputValue { get; protected set; }

        public IReadOnlyList<DeviceTensor> InputTensors { get; protected set; }

        public IDictionary<DeviceTensor, DeviceTensor> GradientTensors { get; protected set; }

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

            Applier = new Applier(_Context, f);
            foreach(DeviceTensor t in InputTensors)
            {
                Applier.AddInputValue(t);
            }
            OutputValue = Applier.AddOutputValue(OutputTensor.Name);
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

            var invocation = Invoke();
            if (invocation.IsAllocated)
            {
                if (OutputTensor.CreateView<T>(MemoryMapType.Retain).CopyToAndFree(output.Span))
                {
                    return RunStatus.Success;
                }
                else
                {
                    RunStatusMessage = invocation.LastStatusString;
                    return RunStatus.ErrorExecuting;
                }
            }
            else
            {
                RunStatusMessage = invocation.LastStatusString;
                return RunStatus.ErrorExecuting;
            }
            
        }

        public RunStatus Run(IVariable<T> output, out IVariable<T> gradient, params IVariable<T>[] input)
        {
            gradient = null;
            RunStatus s = Run(output, input);
            if (s != RunStatus.Success)
            {
                return s;
            }
            Gradient gc = new Gradient(Context, OutputValue);
            Composer c = new Composer(_Context);
            GradientTensors = new Dictionary<DeviceTensor, DeviceTensor>();
            for (int i = 0; i < InputTensors.Count; i++)
            {
                DeviceTensor t = InputTensors[i];
                Value grad = gc.ComputeWrt(t);
                if (!grad.IsAllocated) continue;
                c.AddInputPlaceholder(InputTensors[i].Name, InputTensors[i].DimensionCount);
                DeviceTensor gt = new DeviceTensor(t.Device, t.Shape, grad.Name);
                c.AddOutputValue(gt);
                c.AddUpdate(gt, grad);
                GradientTensors.Add(t, gt);
            }

            Function gf = c.BuildFunction();
            Invoker<int> ginv = new Invoker<int>(_Context, gf, InputTensors.ToArray(), GradientTensors.Values.ToArray());
            Invocation<int> ginvc = ginv.Invoke();
            if (!ginvc.IsAllocated)
            {
                return RunStatus.ErrorComputingGradient;
            }
            var gv = GradientTensors.First().Value.CreateView<T>(MemoryMapType.Retain);
            if (!gv.CopyToAndFree(gradient.Span))
            {
                gv.Free();
                return RunStatus.ErrorComputingGradient;
            }
            else
            {
                return RunStatus.Success;
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
                else if (!iv.Strides.SequenceEqual(id.Stride))
                {
                    throw new ArgumentException($"The stride of kernel input tensor {iv.Name} does not match the " +
                        $"stride of the input data variable {id.Name}.");
                }
            }
        }
    }
}
