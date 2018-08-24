using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    /// <summary>
    /// A direct acyclic graph (DAG) built out of flows.
    /// </summary>
    public class FlowGraph
    {
        public IReadOnlyList<Flow> Flows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Flow flow)
        {
            throw new NotImplementedException();
        }

        public void Add(Beam beam)
        {
            throw new NotImplementedException();
        }

        public void Unite(Symbol s1, Symbol s2)
        {
            throw new NotImplementedException();
        }
    }
}
