using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface IDeviceBuffer
    {
        DeviceType DeviceType { get; }
        IShape Shape { get; }
    }
}
