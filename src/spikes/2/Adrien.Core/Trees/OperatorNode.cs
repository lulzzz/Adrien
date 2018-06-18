using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class OperatorNode : TreeNode
    {
        public Op Op { get; protected set; }

        public TreeNode Left { get; protected set; }

        public TreeNode Right { get; protected set; }
    }
}
