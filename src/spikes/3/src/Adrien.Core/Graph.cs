using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// A direct acyclic graph (DAG) built out of tiles.
    /// </summary>
    public class Graph
    {
        private readonly List<Edge> _edges;

        public IReadOnlyList<Edge> Edges => _edges;

        public Graph()
        {
            _edges = new List<Edge>();
        }

        public void Add(Edge edge)
        {
            _edges.Add(edge);
        }
    }
}
