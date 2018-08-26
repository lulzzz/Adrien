using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// Multidimensional index intended for Einstein notations.
    /// </summary>
    /// <remarks>
    /// The index is multi-dimensional in order to facilitate
    /// generic notations where the rank of the symbol is not
    /// known prior to the geometric inference.
    /// </remarks>
    public class Index
    {
        public IReadOnlyList<Range> Ranges { get; set; }
    }
}
