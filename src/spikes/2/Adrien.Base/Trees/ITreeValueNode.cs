using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public interface ITreeValueNode : ITreeNode
    {
        ValueNodeType NodeType { get; }
        object Value { get; }
        T ValueAs<T>() where T : class;
    }
}
