using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// A direct acyclic graph (DAG) built out of tiles.
    /// </summary>
    public class Graph
    {
        public IReadOnlyList<Tile> Tiles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<Edge> Edges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Edge edge)
        {
            throw new NotImplementedException();
        }
    }
}
