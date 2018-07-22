using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Adrien
{
    internal class IVariableDebugView<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        internal IVariableDebugView(Var<T> var)
        {
            
        }
    }
}
