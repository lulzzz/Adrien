using System.Collections.Generic;

namespace Adrien.Core
{
    public enum EdgeKind
    {
        Tile,

        /// <summary>
        /// No-op, re-interpret a tensor under a series of compatible geometric shapes.
        /// </summary>
        /// <remarks>
        /// Reshaping cannot change <see cref="ElementKind"/> associated to a variable.
        /// It cannot change the size (i.e. product of all dimensions) of the variable
        /// either.
        ///
        /// Reshaping is only redefining the geometric interpretation of variable.
        /// Numerically, the reshape operation is a no-op and has no numerical effect
        /// on the tensor itself.
        ///
        /// The reshape operation can be either simple or complex. A simple reshape
        /// operation reinterprets a single variable as another variable with a
        /// compatible shape.
        ///
        /// A complex reshape operation reinterprets a single variable as a list of
        /// variables, which, put together, represent a compatible shape. Complex
        /// reshape is intended for "slice" operations.
        /// 
        /// </remarks>
        Reshape,
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
        /// <remarks>
        /// Semantically, the input and output variables are respectively
        /// mapped - in the same order - to the input and output symbols
        /// of the tile.
        /// </remarks>
        public Edge(Tile tile, IReadOnlyList<Variable> inputs, IReadOnlyList<Variable> outputs)
        {
            Kind = EdgeKind.Tile;
            Tile = tile;
            Inputs = inputs;
            Outputs = outputs;
        }

        /// <summary>Reshape edge.</summary>
        public Edge(Variable input, IReadOnlyList<Variable> outputs)
        {
            Kind = EdgeKind.Reshape;
            Inputs = new[] {input};
            Outputs = outputs;
        }
    }
}