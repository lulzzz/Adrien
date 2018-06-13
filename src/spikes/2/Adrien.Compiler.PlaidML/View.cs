using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler.PlaidML
{
    public class View<T> : PlaidMLApi<View<T>> where T : unmanaged
    {
        public View(Mapping mapping) : base(mapping.Context)
        {
            Mapping = mapping;
        }

        #region Properties
        public Mapping Mapping { get; protected set; }

        public DeviceBuffer Buffer => Mapping.Buffer;

        public Shape Shape => Buffer.Shape;

        public ulong Length => Shape.ElementCount;
        
        #endregion
    }
}
