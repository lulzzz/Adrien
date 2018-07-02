using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IDeviceBuffer
    {
        DeviceType DeviceType { get; }
        IShape Shape { get; }
    }
}
