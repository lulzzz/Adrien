using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Adrien.Compiler.PlaidML.Bindings;
using Adrien.Compiler.PlaidML.Generator;

namespace Adrien.Compiler.PlaidML
{
    public class TileCompiler : PlaidMLApi<TileCompiler>, ICompiler 
    {
        public Dictionary<string, object> Options { get; }

        public ITensorContext TensorContext { get; }

        public bool Initialized { get; protected set; }

        public CompilerStatus Status { get; protected set; }

        public Settings Settings => _Context.settings;

        public string SessionId { get; protected set; }

        public DeviceEnumerator DeviceEnumerator { get; protected set; }

        public int DeviceCount => DeviceEnumerator.Count;
       
        public Device KernelDevice { get; protected set; }

        public Dictionary<string, object> KernelDeviceProperties { get; protected set; }

        
        public TileCompiler(Dictionary<string, object> options = null) : base(new Context())
        {
            if (!_Context.IsAllocated)
            {
                return;
            }
            Options = options;
            SessionId = Settings.StartNewSession();
            DeviceEnumerator = new DeviceEnumerator(_Context);
            if (!DeviceEnumerator.IsAllocated)
            {
                return;
            }
            if (DeviceEnumerator.ValidDevices.Count < 1)
            {
                Error("No valid devices available.");
                return;
            }
            IsAllocated = true;
            KernelDevice = OpenFirstDevice();
            KernelDeviceProperties = JsonConvert.DeserializeObject<Dictionary<string, object>>
               (KernelDevice.DeviceConfig.Details);
            Initialized = true;
        }
       

        public Device OpenFirstDevice()
        {
            ThrowIfNotAllocated();
            if (DeviceEnumerator.Count == 0)
            {
                throw new Exception("No devices were enumerated.");
            }
            else
            {
                return new Device(_Context, DeviceEnumerator.ValidDevices[0]);
            }
        }

        public Function CreateFunction(TileGenerator generator)
        {
            ThrowIfNotAllocated();
            ThrowIfNotInitialized();
            Function f = new Function(Context, generator.Text);
            if (f.IsAllocated)
            {
                return f;
            }
            else return null;
        }

        public Shape CreateShape<T>(params int[] dimensions) where T : unmanaged
        {
            ThrowIfNotAllocated();
            PlaidmlDatatype datatype = Shape.ToDataType<T>();
            return new Shape(_Context, datatype, dimensions);
        }

        public TensorVariable CreateTensor(Shape shape, string name)
        {
            ThrowIfNotAllocated();
            return new TensorVariable(KernelDevice, shape, name);
        }

        public Function CreateFunction(string code)
        {
            ThrowIfNotAllocated();
            return new Function(_Context, code);
        }


        public bool Compile<TKernel>(IKernel<TKernel> kernel, out IRunnable<TKernel> result) 
            where TKernel : unmanaged, IEquatable<TKernel>, IComparable<TKernel>, IConvertible
        {
            result = null;
            ThrowIfNotInitialized();
            Status = CompilerStatus.Compiling;
            TileGenerator g = new TileGenerator(kernel.ExpressionTree);
            if (!g.Success)
            {
                Status = CompilerStatus.ErrorGeneratingCode;
                return false;
            }
            Function f = CreateFunction(g);
            List<TensorVariable> inputTensors = kernel.Input
                .Select(i => CreateTensor(CreateShape<TKernel>(i.Dimensions), i.Name))
                .ToList();
            TensorVariable outputTensor = CreateTensor(CreateShape<TKernel>(kernel.Output.Dimensions),
                kernel.Output.Name);

            //inputTensors.
            return false;
        }

        internal void ThrowIfNotInitialized()
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("This compiler instance is not initialized.");
            }
        }
    }
}
