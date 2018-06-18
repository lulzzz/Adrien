using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public class ValueNode<T> : TreeNode where T : unmanaged
    {
        public IShape<T> Shape { get; internal set; }

        public object Data { get; internal set; }
    }
}
