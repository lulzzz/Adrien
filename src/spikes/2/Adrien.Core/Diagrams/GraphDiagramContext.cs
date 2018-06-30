using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Drawing;
using Node = Microsoft.Msagl.Drawing.Node;
using Edge = Microsoft.Msagl.Drawing.Edge;
using GeometryNode = Microsoft.Msagl.Core.Layout.Node;
using GeometryEdge = Microsoft.Msagl.Core.Layout.Edge;
using GeometryPoint = Microsoft.Msagl.Core.Geometry.Point;

using Adrien.Trees;

namespace Adrien.Diagrams
{
    public class GraphDiagramContext : TreeVisitorContext<Op, Node, Node>
    {
        public GraphDiagramContext(ExpressionTree tree) : base(tree)
        {
            
        }
    }
}
