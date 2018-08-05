using Node = Microsoft.Msagl.Drawing.Node;
using Adrien.Trees;

namespace Adrien.Diagrams
{
    public class GraphDiagramContext : TreeVisitorContext<TensorOp, Node, Node>
    {
        public GraphDiagramContext(ExpressionTree tree) : base(tree)
        {
        }
    }
}