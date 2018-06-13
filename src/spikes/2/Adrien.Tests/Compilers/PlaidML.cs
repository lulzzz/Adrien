using System;

using Xunit;

using Adrien.Compiler.PlaidML;
using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Tests.Compilers
{
    public class PlaidMLCompilerTests
    {
        protected Context context;

        public PlaidMLCompilerTests()
        {
            Driver.CreateDefaultLogger("Adrien.Tests.log");
            context = new Context();
        }

        [Fact]
        public void CanGetVersion()
        {
            string s = plaidml.PlaidmlGetVersion();
            Assert.False(string.IsNullOrEmpty(plaidml.PlaidmlGetVersion()));
        }

        [Fact]
        public void CanCreateContext()
        {
            Context ctx = new Context();
            Assert.True(ctx.IsAllocated);
            ctx.Free();
            Assert.False(ctx.IsAllocated);
        }

        [Fact]
        public void CanLoadSettings()
        {
            Settings settings = new Settings();
            Assert.True(settings.IsLoaded);
            Assert.True(settings.Dict.ContainsKey("platform"));
        }

        [Fact]
        public void CanGetValidDevices()
        {
            DeviceEnumerator e = new DeviceEnumerator(new Context());
            Assert.True(e.ValidDevices.Count > 0);
            DeviceConfig d = e.ValidDevices[0];
            Assert.True(d.Id.IsNotNullOrEmpty());
            Assert.True(d.Config.IsNotNullOrEmpty());
            Assert.True(d.Description.IsNotNullOrEmpty());
            Assert.True(d.Details.IsNotNullOrEmpty());
            Assert.True(e.GetConfigSource().IsNotNullOrEmpty());
            e.Free();
        }

        [Fact]
        public void CanOpenDevice()
        {
            Device device = new Device(context);
            Assert.True(device.IsAllocated);
            Assert.True(device.IsOpen);
            device.Close();
            Assert.True(device.IsClosed);
            device.Free();
            Assert.False(device.IsAllocated);
        }

        [Fact]
        public void CanConstructShape()
        {
            Shape s = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_FLOAT32, 4);
            Assert.True(s.IsAllocated);
            Assert.Equal(PlaidmlDatatype.PLAIDML_DATA_FLOAT32, s.DataType);
            Assert.Equal(1ul, s.DimensionCount);
            (ulong size, long stride) dim = s.Dimensions[0];
            Assert.Equal(4ul, dim.size);
            Assert.Equal(1L, dim.stride);
        }

        [Fact]
        public void CanConstructBuffer()
        {
            Device device = new Device(context);
            Shape s1 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_FLOAT32, 4, 8, 8);
            device.CreateBuffer(s1);
            Assert.Single(device.Buffers);
            DeviceBuffer buffer = device.Buffers[0];
            Assert.Equal(8UL * 8 * 4 * 4, buffer.SizeInBytes);
            Shape s2 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_INT64, 13, 5);
            device.CreateBuffer(s2);
            buffer = device.Buffers[1];
            Assert.Equal((13UL * 5 * 8), buffer.SizeInBytes);
        }

        [Fact]
        public void CanConstructMapping()
        {
            Device device = new Device(context);
            Shape s1 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_FLOAT64, 4, 8, 8);
            device.CreateBuffer(s1);
            Assert.Single(device.Buffers);
            DeviceBuffer buffer = device.Buffers[0];
            Assert.Equal(8UL * 8 * 4 * 8, buffer.SizeInBytes);
            Mapping m = new Mapping(buffer);
            Span<long> span = m.GetSpan<long>();
            Assert.Equal((int) s1.ElementCount, span.Length);
        }
    }
}
