using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Compiler : PlaidMLApi<Compiler>
    {
        public Compiler() : base(new Context())
        {    
            SessionId = Settings.StartNewSession();
            DeviceEnumerator = new DeviceEnumerator(context);
            if (!DeviceEnumerator.IsAllocated)
            {
                return;
            }
            IsAllocated = true;
        }

        #region Properties
        public bool Initialized => IsAllocated;
        public Settings Settings => context.settings;

        public string SessionId { get; protected set; }
        
        public DeviceEnumerator DeviceEnumerator { get; protected set; }

        public int DeviceCount => DeviceEnumerator.Count;
        #endregion

        #region Methods
        public void ThrowIfNotInitialized()
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("This compiler instance is not initialized.");
            }
        }

        
        public Device OpenFirstDevice()
        {
            ThrowIfNotInitialized();
            if (DeviceEnumerator.Count == 0)
            {
                throw new Exception("No devices were enumerated.");
            }
            else
            {
                return new Device(context, DeviceEnumerator.ValidDevices[0]);
            }
        }

        public Shape CreateShape<T>(params int[] dimensions) where T : unmanaged
        {
            ThrowIfNotInitialized();
            PlaidmlDatatype datatype = Shape.ToDataType<T>();
            return new Shape(context, datatype, dimensions);
        }

        public Tensor CreateTensor(Device device, Shape shape, string name)
        {
            ThrowIfNotInitialized();
            return new Tensor(device, shape, name);
        }

        public Function CreateFunction(string code)
        {
            ThrowIfNotInitialized();
            return new Function(context, code);
        }
        #endregion
    }
}
