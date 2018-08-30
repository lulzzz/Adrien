using System.Collections.Generic;

namespace Adrien.Core.Numerics
{
    /// <summary>
    /// Intended to be inherited by backend implementations for Adrien.
    /// </summary>
    public interface ITensorAllocator
    {
        /// <summary>
        /// Instantiate a tensor from a given shape.
        /// </summary>
        ITensor Create(Shape shape, string name);

        /// <summary>
        /// Create a list of child tensors that share the same
        /// backing than the parent 'tensor'. Intended for complex
        /// reshape operations.
        /// </summary>
        IReadOnlyList<ITensor> Slice(ITensor tensor, IReadOnlyList<Shape> shapes);
    }
}
