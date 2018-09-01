using System;
using Adrien.Ast;
using Adrien.Ast.Extensions;

namespace Adrien.Numerics.Reference
{
    public class Tensor<T> : ITensor<T>
    {
        private readonly Memory<T> _buffer;

        public ElementKind Kind { get; }

        public int Count => _buffer.Length;

        public string Name { get; }

        public Memory<T> Buffer => _buffer;

        public Tensor(string name, Memory<T> buffer)
        {
            Kind = typeof(T).GetMatchingElementKind();
            Name = name;
            _buffer = buffer;
        }

        public void Dispose()
        {
            // do nothing
        }
    }

    public static class TensorExtensions
    {
        public static Type GetTensorType(this ElementKind kind)
        {
            return typeof(Tensor<>).MakeGenericType(kind.GetMatchingType());
        }
    }
}
