using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// A logical compute unit within a graph.
    /// </summary>
    public class Edge
    {
        public Tile Tile { get; }

        public IReadOnlyList<Variable> Inputs { get; }

        public IReadOnlyList<Variable> Outputs { get; }

        public Edge(Tile tile, IReadOnlyList<Variable> inputs, IReadOnlyList<Variable> outputs)
        {
            Tile = tile;
            Inputs = inputs;
            Outputs = outputs;
        }
    }
}
