namespace Adrien.Compiler
{
    public interface IDeviceBuffer
    {
        DeviceType DeviceType { get; }
        IShape Shape { get; }
    }
}