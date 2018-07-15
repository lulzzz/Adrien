using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using Adrien.Compiler.PlaidML;
using Adrien.Compiler.PlaidML.Bindings;
using Adrien.Compiler.PlaidML.Generator;

using Adrien.Notation;

namespace Adrien.Tests.Compilers
{
    public class PlaidMLCompilerApiTests
    {
        protected Context context;

        public PlaidMLCompilerApiTests()
        {
            CompilerDriver.CreateDefaultLogger("Adrien.Tests.log");
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
            MemoryMapping m = new MemoryMapping(buffer);
            Span<long> span = m.GetSpan<long>();
            Assert.Equal((int) s1.ElementCount, span.Length);
        }

        [Fact]
        public void CanConstructTensorVariableView()
        {
            Device device = new Device(context);
            Shape s1 = new Shape(context, PlaidmlDatatype.PLAIDML_DATA_FLOAT64, 2, 3);
            Compiler.PlaidML.DeviceTensor t = new Compiler.PlaidML.DeviceTensor(device, s1, "t");
            TensorVariableView<Int64> v = t.CreateView<Int64>(MemoryMapType.Discard);
            Int64[,] array = { { 0, 1, 3 }, { 4, 5, 6 } };
            v.CopyFromAndFree(array.Flatten<Int64>().ToArray());
            Assert.Throws<InvalidOperationException>(() => v.Free());
            TensorVariableView<Int64> v2 = t.CreateView<long>(MemoryMapType.Retain);
            Assert.Equal(3, v2[2]);
            Assert.Equal(6, v2[5]);
        }

        [Fact]
        public void CanInvokeFunction()
        {
            Device device = new Device(context);
            string code = @"function (I[N]) -> (O) {
                                O[i: N] = +(I[k]), i - k < N;
                            }";
            Function f = new Function(context, code);
            Compiler.PlaidML.DeviceTensor i = new Compiler.PlaidML.DeviceTensor(device, new Shape(context, PlaidmlDatatype.PLAIDML_DATA_INT32, 6), "I");
            Compiler.PlaidML.DeviceTensor o = new Compiler.PlaidML.DeviceTensor(device, new Shape(context, PlaidmlDatatype.PLAIDML_DATA_INT32, 6), "O");
            
            Int32[] input_data = { 0, 1, 3,  4, 5, 6 };
            i.CreateView<Int32>(MemoryMapType.Discard).CopyFromAndFree(input_data);
      
            TensorVariableView<Int32> v = i.CreateView<Int32>(MemoryMapType.Retain);
            Assert.Equal(3, v[2]);
            Invoker<int> invoker = new Invoker<int>(context, f, new Compiler.PlaidML.DeviceTensor[] { i }, new Compiler.PlaidML.DeviceTensor[] { o });
          
            Shape x = invoker.GetOutputShape("O");
            Assert.True(x.ElementCount == 6);
            Assert.True(invoker.AllVariablesSet);
            Invocation<Int32> inv = invoker.Invoke();
            TensorVariableView<Int32> R = o.CreateView<Int32>(MemoryMapType.Retain);
            Assert.Equal(6, R.ElementCount);
            Assert.Equal(4, R[2]);
        }

        [Fact]
        public void CanGenerateTileFunction()
        {
            var A = Notation.Tensor.TwoD("A", (8, 17), "a", out Index a, out Index b);
            var B = Notation.Tensor.TwoD("B", (8, 17));
            TileGenerator g = new TileGenerator((A[a, b] * B[a, b]).ToTree());
            Assert.Equal("A[a, b] * B[a, b]", g.Text);
            g = new TileGenerator(A[b].ToTree());
            Assert.Equal("A[b]", g.Text);
        }
    }
}
