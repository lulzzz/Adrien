using System.Collections.Generic;

namespace Adrien.Core.Numerics
{
    /// <summary>
    /// A logical compute unit within a flow.
    /// </summary>
    public class Operation
    {
        /// <summary>Identify the the name of the kernel.</summary>
        public string Kernel { get; }

        /// <summary>Identify the names of the tensors.</summary>
        public IReadOnlyList<string> Tensors { get; }
    }
}
