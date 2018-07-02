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
using Label = Microsoft.Msagl.Drawing.Label;

using GeometryNode = Microsoft.Msagl.Core.Layout.Node;
using GeometryEdge = Microsoft.Msagl.Core.Layout.Edge;
using GeometryLabel = Microsoft.Msagl.Core.Layout.Label;
using GeometryPoint = Microsoft.Msagl.Core.Geometry.Point;

using AGL.Drawing.Gdi;
using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Diagrams
{
    public class GraphDiagram : TreeVisitor<TensorOp, Node, Node>
    {
        public Graph Graph { get; protected set; }

        public SugiyamaLayoutSettings LayoutSettings { get; protected set; }

        public double NodeWidth { get; protected set; } = 40;

        public double NodeHeight { get; protected set; } = 10;

        public GraphDiagram(ExpressionTree tree) : base(tree, false)
        {
            this.Context = new GraphDiagramContext(tree);

            Graph = new Graph
            {
                GeometryGraph = new GeometryGraph()
            };
            this.Visit(Tree);
            AfterVisit();
        }


        public override void VisitLeaf(ITreeValueNode node)
        {
            Node srcNode = Context.InternalNode;
            Node graphNode;
            switch (node.Value)
            {
                case Term t:
                    graphNode = Graph.AddNode(t.Id);
                    graphNode.Label = new Label(t.Name);
                    break;
                default: throw new Exception($"Unknown value in ValueNode: {node.Value} of type {node.Value.GetType().Name}.");
            }
            
            Graph.AddEdge(srcNode.Id, graphNode.Id);
        }

        public override void VisitInternal(ITreeOperatorNode<TensorOp> on)
        {
            Node srcNode = Context.IsInternal ? Context.InternalNode : null;
            Node graphNode = Graph.AddNode(on.Id.ToString());
            graphNode.Label = new Label(on.Op.ToString());
            if (srcNode != null)
            {
                Graph.AddEdge(srcNode.Id, graphNode.Id);
            }

            using (var context = Context.Internal(graphNode))
            {
                base.VisitInternal(on);
            }
        }

        public override void AfterVisit()
        {
            LayoutSettings = new SugiyamaLayoutSettings
            {
                Transformation = PlaneTransformation.Rotation(Math.PI),
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.Spline },
                MinNodeHeight = 10,
                MinNodeWidth = 20,

            };
            //LayoutSettings.NodeSeparation *= 2;
            Graph.LayoutAlgorithmSettings = LayoutSettings;

            
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
            using (Bitmap bmp = new Bitmap(1200, 1200, PixelFormat.Format32bppPArgb))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle rect = new Rectangle(0, 0, 1200, 1200);
                
                g.Clear(System.Drawing.Color.White);
                
                GraphDiagramUtil.SetGraphTransform(Graph.GeometryGraph, rect, g);
                LayeredLayout layout = new LayeredLayout(Graph.GeometryGraph, LayoutSettings);
                layout.Run();
                GraphDiagramUtil.DrawFromGraph(rect, Graph.GeometryGraph, g);
                bmp.Save("graph.bmp", ImageFormat.Bmp);
            }
        }
    }
}
