using System;
using System.Collections.Generic;

namespace Adrien.Ast
{
    /// <summary>
    /// A direct acyclic graph (DAG) built out of tiles.
    /// </summary>
    public class Graph
    {
        public IReadOnlyList<Edge> Edges { get; }

        public Graph(IReadOnlyList<Edge> edges)
        {
            Edges = edges ?? throw new ArgumentNullException(nameof(edges));
        }
    }
}