using System.Collections.Generic;

namespace Adrien.Core
{
    public enum EdgeKind
    {
        Tile,

        /// <summary>
        /// No-op, only interpreting a tensor under a compatible geometric shape.
        /// </summary>
        /// <remarks>
        /// Reshaping cannot change <see cref="ElementKind"/> associated to a variable.
        /// It cannot change the size (i.e. product of all dimensions) of the variable
        /// either.
        ///
        /// Reshaping is only redefining the geometric interpretation of variable.
        /// Numerically, the reshape operation is a no-op and has no numerical effect
        /// on the tensor itself.
        /// </remarks>
        Reshape
    }

    /// <summary>
    /// A logical compute unit within a graph.
    /// </summary>
    public class Edge
    {
        public EdgeKind Kind { get; }

        public Tile Tile { get; }

        public IReadOnlyList<Variable> Inputs { get; }

        public IReadOnlyList<Variable> Outputs { get; }

        /// <summary>Tile edge.</summary>
        public Edge(Tile tile, IReadOnlyList<Variable> inputs, IReadOnlyList<Variable> outputs)
        {
            Kind = EdgeKind.Tile;
            Tile = tile;
            Inputs = inputs;
            Outputs = outputs;
        }

        /// <summary>Reshape edge.</summary>
        public Edge(IReadOnlyList<Variable> inputs, IReadOnlyList<Variable> outputs)
        {
            Kind = EdgeKind.Reshape;
            Inputs = inputs;
            Outputs = outputs;
        }
    }
}
