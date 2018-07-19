using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public interface IChild
    {
        ITerm Parent { get; }
    }
}
