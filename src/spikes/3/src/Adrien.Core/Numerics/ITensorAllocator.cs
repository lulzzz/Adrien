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
    }
}
