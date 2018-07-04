using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Compiler
{
    public class Kernel<T> where T : unmanaged
    {
        public Kernel(ExpressionTree expr, IVariable<T> output, params IVariable<T>[] input)
        {

        }
    }
}
