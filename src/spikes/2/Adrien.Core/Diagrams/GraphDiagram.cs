using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Drawing;
using System.Drawing.Imaging;

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

using AGL.Drawing.Gdi;
using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Diagrams
{
    public class GraphDiagram : TreeVisitor<Op>
    {
        public Graph Graph { get; protected set; }

        public SugiyamaLayoutSettings LayoutSettings { get; }

        public GraphDiagram(ExpressionTree tree) : base(tree, false)
        {
            this.Context = new GraphDiagramContext(tree);

            Graph = new Graph();
            Graph.GeometryGraph = new GeometryGraph();
            LayoutSettings = new SugiyamaLayoutSettings
            {
                Transformation = PlaneTransformation.Rotation(Math.PI / 2),
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.Spline },
                MinNodeHeight = 10,
                MinNodeWidth = 20,

            };
            LayoutSettings.NodeSeparation *= 2;
            Graph.LayoutAlgorithmSettings = LayoutSettings;
            this.Visit(Tree.Children.ElementAt(0));
            AfterVisit();
        }

        public override void VisitLeaf(ITreeValueNode node)
        {
            switch (node.Value)
            {
                case Term t:
                    Node n = Graph.AddNode(t.Name);
                    break;
                default: throw new Exception($"Unknown value in ValueNode: {node.Value} of type {node.Value.GetType().Name}.");
            }
        }

        public override void VisitInternal(ITreeOperatorNode<Op> on)
        {
            base.VisitInternal(on);
            if (on.Parent != null)
            {
                Graph.AddEdge(on.Parent.Label, on.Label);
            }
            
        }

        public override void AfterVisit()
        {
            foreach (Node n in Graph.Nodes)
            {
                Graph.GeometryGraph.Nodes.Add(new GeometryNode(CurveFactory.CreateRectangle(20, 10, new GeometryPoint()), n));
            }

            foreach (Edge e in Graph.Edges)
            {
                GeometryNode source = Graph.FindGeometryNode(e.SourceNode.Id);
                GeometryNode target = Graph.FindGeometryNode(e.TargetNode.Id);
                Graph.GeometryGraph.Edges.Add(new GeometryEdge(source, target));
            }
            Graph.GeometryGraph.UpdateBoundingBox();
            using (Bitmap bmp = new Bitmap(400, 400, PixelFormat.Format32bppPArgb))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(System.Drawing.Color.White);
                Rectangle rect = new Rectangle(0, 0, 400, 400);
                //GdiUtils.SetGraphTransform(graph, rect, g);
                LayeredLayout layout = new LayeredLayout(Graph.GeometryGraph, LayoutSettings);
                layout.Run();
                GdiUtils.DrawFromGraph(rect, Graph.GeometryGraph, g);
                bmp.Save("graph.bmp", ImageFormat.Bmp);
            }
        }
    }
}
