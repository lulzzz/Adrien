using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien
{
    public interface IVariable
    {
        string Name { get; }
        IShape Shape { get; }
    }
}

