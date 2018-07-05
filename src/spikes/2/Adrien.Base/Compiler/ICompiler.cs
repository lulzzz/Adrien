using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public interface ICompiler<T> where T : unmanaged
    {
        bool Compile(IKernel<T> kernel);
    }
}
