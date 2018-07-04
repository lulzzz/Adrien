using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IKernel<T> where T : unmanaged
    {
        DeviceType DeviceType { get; }

        IVariable<T> Ouput { get; }

        IVariable<T>[] Inputs { get; }
    }
}
