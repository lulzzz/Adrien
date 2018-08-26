using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    /// <summary>
    /// A logical compute unit within a graph.
    /// </summary>
    public class Edge
    {
        public Tile Tile { get; }

        public IReadOnlyList<Variable> Inputs
        {
            get {  throw new NotImplementedException(); }
        }

        public IReadOnlyList<Variable> Ouputs
        {
            get {  throw new NotImplementedException(); }
        }
    }
}
