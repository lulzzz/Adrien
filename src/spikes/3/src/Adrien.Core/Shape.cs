using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// The shape is the geometric characterization of variables,
    /// symbols and tensors.
    /// </summary>
    public class Shape
    {
        public ElementKind Kind { get; set; }

        public IReadOnlyList<int> Dimensions { get; }
    }
}
