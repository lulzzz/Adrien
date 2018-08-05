#region License and Attribution

/**
 * Contains code from Microsoft Automatic Graph Layout : https://github.com/Microsoft/automatic-graph-layout/
 * Microsoft Automatic Graph Layout,MSAGL 

 * Copyright (c) Microsoft Corporation

 * All rights reserved. 

*  MIT License 

* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* ""Software""), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:

* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.

* THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
* LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
* OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
* WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/

#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Math;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Point = Microsoft.Msagl.Core.Geometry.Point;

namespace Adrien.Diagrams
{
    public class GraphDiagramUtil
    {
        public static void DrawFromGraph(System.Drawing.Rectangle clientRectangle, GeometryGraph geometryGraph,
            Graphics graphics)
        {
            SetGraphTransform(geometryGraph, clientRectangle, graphics);
            var pen = new Pen(Brushes.Black);
            DrawNodes(geometryGraph, pen, graphics);
            DrawEdges(geometryGraph, pen, graphics);
        }

        public static void SetGraphTransform(GeometryGraph geometryGraph, System.Drawing.Rectangle rectangle,
            Graphics graphics)
        {
            RectangleF clientRectangle = rectangle;
            var gr = geometryGraph.BoundingBox;
            if (clientRectangle.Height > 1 && clientRectangle.Width > 1)
            {
                var scale = Min(clientRectangle.Width * 0.9 / gr.Width, clientRectangle.Height * 0.9 / gr.Height);
                var g0 = (gr.Left + gr.Right) / 2;
                var g1 = (gr.Top + gr.Bottom) / 2;

                var c0 = (clientRectangle.Left + clientRectangle.Right) / 2;
                var c1 = (clientRectangle.Top + clientRectangle.Bottom) / 2;
                var dx = c0 - scale * g0;
                var dy = c1 - scale * g1;
                /*
                //instead of setting transormation for graphics it is possible to transform the geometry graph, just to test that GeometryGraph.Transform() works
            
                var planeTransformation=new PlaneTransformation(scale,0,dx, 0, scale, dy); 
                geometryGraph.Transform(planeTransformation);
                */
                graphics.Transform = new Matrix((float) scale, 0, 0, (float) scale, (float) dx, (float) dy);
            }
        }

        static void DrawEdges(GeometryGraph geometryGraph, Pen pen, Graphics graphics)
        {
            foreach (Edge e in geometryGraph.Edges)
                DrawEdge(e, pen, graphics);
        }

        static void DrawEdge(Edge e, Pen pen, Graphics graphics)
        {
            graphics.DrawPath(pen, CreateGraphicsPath(e.Curve));

            if (e.EdgeGeometry != null && e.EdgeGeometry.SourceArrowhead != null)
                DrawArrow(pen, graphics, e.Curve.Start, e.EdgeGeometry.SourceArrowhead.TipPosition);
            if (e.EdgeGeometry != null && e.EdgeGeometry.TargetArrowhead != null)
                DrawArrow(pen, graphics, e.Curve.End, e.EdgeGeometry.TargetArrowhead.TipPosition);
        }

        internal static GraphicsPath CreateGraphicsPath(ICurve iCurve)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            if (iCurve == null)
                return null;
            Curve c = iCurve as Curve;
            if (c != null)
            {
                foreach (ICurve seg in c.Segments)
                {
                    CubicBezierSegment cubic = seg as CubicBezierSegment;
                    if (cubic != null)
                        graphicsPath.AddBezier(PointF(cubic.B(0)), PointF(cubic.B(1)), PointF(cubic.B(2)),
                            PointF(cubic.B(3)));
                    else
                    {
                        LineSegment ls = seg as LineSegment;
                        if (ls != null)
                            graphicsPath.AddLine(PointF(ls.Start), PointF(ls.End));

                        else
                        {
                            Ellipse el = seg as Ellipse;
                            if (el != null)
                            {
                                graphicsPath.AddArc((float) (el.Center.X - el.AxisA.X),
                                    (float) (el.Center.Y - el.AxisB.Y), (float) (el.AxisA.X * 2),
                                    Abs((float) el.AxisB.Y * 2), EllipseStartAngle(el), EllipseSweepAngle(el));
                            }
                        }
                    }
                }
            }
            else
            {
                var ls = iCurve as LineSegment;
                if (ls != null)
                    graphicsPath.AddLine(PointF(ls.Start), PointF(ls.End));
            }

            return graphicsPath;
        }

        static PointF PointF(Point point)
        {
            return new PointF((float) point.X, (float) point.Y);
        }

        static void DrawArrow(Pen pen, Graphics graphics, Point start, Point end)
        {
            float arrowAngle = 30;

            Point dir = end - start;
            Point h = dir;
            dir /= dir.Length;

            Point s = new Point(-dir.Y, dir.X);

            s *= h.Length * ((float) Tan(arrowAngle * 0.5f * (PI / 180.0)));

            var points = new PointF[]
            {
                MsaglPointToDrawingPoint(start + s), MsaglPointToDrawingPoint(end), MsaglPointToDrawingPoint(start - s)
            };

            graphics.FillPolygon(pen.Brush, points);
        }

        public static void DrawNodes(GeometryGraph geometryGraph, Pen pen, Graphics graphics)
        {
            foreach (Node n in geometryGraph.Nodes)
                DrawNode(n, pen, graphics);
        }

        public static float EllipseSweepAngle(Ellipse el)
        {
            return (float) ((el.ParEnd - el.ParStart) / PI * 180);
        }

        public static float EllipseStartAngle(Ellipse el)
        {
            return (float) (el.ParStart / PI * 180);
        }

        public static void DrawNode(Node n, Pen pen, Graphics graphics)
        {
            ICurve curve = n.BoundaryCurve;
            Ellipse el = curve as Ellipse;
            if (el != null)
            {
                graphics.DrawEllipse(pen, new RectangleF((float) el.BoundingBox.Left, (float) el.BoundingBox.Bottom,
                    (float) el.BoundingBox.Width, (float) el.BoundingBox.Height));
            }
            else
                graphics.DrawPath(pen, CreateGraphicsPath(curve));
        }

        public static System.Drawing.Point MsaglPointToDrawingPoint(Point point)
        {
            return new System.Drawing.Point((int) point.X, (int) point.Y);
        }

        public static Node AddNode(string id, GeometryGraph graph, double w, double h)
        {
            Node node = new Node(CreateCurve(w, h), id);
            graph.Nodes.Add(node);
            return node;
        }

        public static Edge AddEdge(GeometryGraph graph, Node source, Node target)
        {
            Edge e = new Edge(source, target);
            graph.Edges.Add(e);
            return e;
        }

        public static ICurve CreateCurve(double w, double h)
        {
            return CurveFactory.CreateRectangle(w, h, new Point());
        }
    }
}