using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface ITreeVisitor<TOp>
    {
        void Visit(ITreeNode node);
        void VisitInternal(ITreeOperatorNode<TOp> node);
        void VisitLeaf(ITreeValueNode node);
        void AfterVisitTree();
    }
}
