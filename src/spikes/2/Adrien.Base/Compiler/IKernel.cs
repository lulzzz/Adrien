using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;
namespace Adrien.Compiler
{
    public interface IKernel<T> where T : unmanaged
    {
        DeviceType DeviceType { get; }

        IExpressionTree ExpressionTree { get; }

        IVariable<T> Output { get; }

        IVariable<T>[] Input { get; }
    }
}
