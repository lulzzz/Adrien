using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface IVariable
    {
        string Name { get; }
        IShape Shape { get; }
    }
}

