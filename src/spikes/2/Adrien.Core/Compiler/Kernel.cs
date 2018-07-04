using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Compiler
{
    public class Kernel<T> where T : unmanaged
    {
        public Kernel(IVariable<T> output, params IVariable<T>[] input)
        {

        }
    }
}
