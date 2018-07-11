using System;
using System.Collections.Generic;

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

        public Settings Settings => _Context.settings;

        public string SessionId { get; protected set; }

        public DeviceEnumerator DeviceEnumerator { get; protected set; }

        public int DeviceCount => DeviceEnumerator.Count;
       
        public Device KernelDevice { get; protected set; }

        public Dictionary<string, object> KernelDeviceProperties { get; protected set; }

        public TileGenerator TileGenerator { get; protected set; }


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

        public Shape CreateShape<T>(params int[] dimensions) where T : unmanaged
        {
            ThrowIfNotAllocated();
            PlaidmlDatatype datatype = Shape.ToDataType<T>();
            return new Shape(_Context, datatype, dimensions);
        }

        public DeviceTensor CreateTensor(Device device, Shape shape, string name)
        {
            ThrowIfNotAllocated();
            return new DeviceTensor(device, shape, name);
        }

        public Function CreateFunction(string code)
        {
            ThrowIfNotAllocated();
            return new Function(_Context, code);
        }


        public bool Compile<TKernel>(IKernel<TKernel> kernel, out IRunnable<TKernel> result) where TKernel : unmanaged, IEquatable<TKernel>, IComparable<TKernel>, IConvertible
        {
            result = null;
            ThrowIfNotInitialized();
            TileGenerator = new TileGenerator(kernel.ExpressionTree);
            if (!TileGenerator.Success)
            {

                return false;
            }
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
