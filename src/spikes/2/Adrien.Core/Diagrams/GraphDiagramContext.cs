using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Diagrams
{
    public class GraphDiagramContext : TreeVisitorContext<Op, ITreeNode>
    {
        public GraphDiagramContext(ExpressionTree tree) : base(tree)
        {
            
        }
    }
}
