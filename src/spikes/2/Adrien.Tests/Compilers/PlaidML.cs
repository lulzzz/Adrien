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
        [Fact(DisplayName = "Can call PlaidML GetVersion")]
        public void CanGetVersion()
        {
            string s = plaidml.PlaidmlGetVersion();
            Assert.False(string.IsNullOrEmpty(plaidml.PlaidmlGetVersion()));
        }

        [Fact(DisplayName = "Can construct a PlaidML context")]
        public void CanCreateCtx()
        {
            Context ctx = new Context();
            Assert.True(ctx.IsAllocated);
            ctx.Free();
            Assert.False(ctx.IsAllocated);
        }

        [Fact(DisplayName = "Can load PlaidML settings")]
        public void CanLoadSettings()
        {
            Settings settings = new Settings();
            Assert.True(settings.IsLoaded);
            Assert.True(settings.Dict.ContainsKey("platform"));
        }

        [Fact(DisplayName = "Can get PlaidML valid devices")]
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

        [Fact(DisplayName = "Can open a PlaidML device")]
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

        [Fact(DisplayName = "Can construct a PlaidML shape")]
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

        [Fact(DisplayName = "Can construct a PlaidML buffer")]
        public void CanConstructBuffer()
        {
            Device device = new Device(context);
            Shape s1 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_FLOAT32, 4, 8, 8);
            device.CreateBuffer(s1);
            Assert.Single(device.Buffers);
            DeviceBuffer buffer = device.Buffers[0];
            Assert.Equal(8UL * 8 * 4 * 4, buffer.Size);
            Shape s2 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_INT64, 13, 5);
            device.CreateBuffer(s2);
            buffer = device.Buffers[1];
            Assert.Equal((13UL * 5 * 8), buffer.Size);
        }
    }
}
