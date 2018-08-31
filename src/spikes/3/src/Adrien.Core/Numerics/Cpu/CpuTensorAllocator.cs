﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Adrien.Core.Extensions;

namespace Adrien.Core.Numerics.Cpu
{
    public class CpuTensorAllocator : ITensorAllocator
    {
        public ITensor Create(Shape shape, string name)
        {
            var createInternal = typeof(CpuTensorAllocator).GetMethod("CreateInternal", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(shape.ElementType());

            return (ITensor)createInternal.Invoke(this, new object[] {shape, name});
        }

        private Tensor<T> CreateInternal<T>(Shape shape, string name)
        {
            var backing = new Memory<T>(new T[shape.ElementCount()]);
            return new Tensor<T>(name, backing);
        }

        public IReadOnlyList<ITensor> Slice(ITensor tensor, IReadOnlyList<Shape> shapes)
        {
            throw new NotImplementedException();
        }
    }
}
