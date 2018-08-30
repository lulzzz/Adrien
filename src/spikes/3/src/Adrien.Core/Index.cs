using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// Multidimensional index intended for Einstein notations.
    /// </summary>
    /// <remarks>
    /// The index is referred as unidimensional if 'Ranges' has
    /// a count of 1. The index is referred as multidimensional
    /// if count is greater than 1.
    /// 
    /// The index can be multidimensional in order to facilitate
    /// generic notations where the rank of the symbol is not
    /// known prior to the geometric inference.
    /// </remarks>
    public class Index
    {
        public string Name { get; }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        public IReadOnlyList<Range> Ranges { get; set; }

        public Index(string name)
        {
            Name = name;
        }
    }
}
