using System.Collections.Generic;

namespace Adrien.Core.Numerics
{
    /// <summary>
    /// Intended to import (resp. export) data into (resp. from) a flow.
    /// </summary>
    /// <remarks>
    /// Implementations of the data binder can be either used to
    /// import source data into their destination tensors, or the
    /// other way around to export tensor data into destination
    /// data recipients. A single implementation is not expected
    /// to be able to do both import and export.
    /// 
    /// The chunks are introduced because the underlying dataset can
    /// be very large. Thus, the logic that consumes the data binder
    /// should not assume that random accesses can be performed for
    /// "free". The intended read/write pattern is to iterate over
    /// one chunk at a time.
    /// </remarks>
    public interface IDataBinder
    {
        int[] ChunkSizes { get; }

        void Bind(int chunk, int index, IReadOnlyDictionary<string, ITensor> tensors);
    }
}
