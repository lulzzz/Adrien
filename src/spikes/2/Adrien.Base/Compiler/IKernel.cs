using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;
namespace Adrien.Compiler
{
    public interface IKernel<T> where T : unmanaged
    {
        DeviceType DeviceType { get; }

        IVariable<T> Ouput { get; }

        IVariable<T>[] Inputs { get; }

        IExpressionTree ExpressionTree { get; }
    }
}
