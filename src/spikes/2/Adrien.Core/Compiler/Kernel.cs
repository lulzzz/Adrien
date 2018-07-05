using System;
using System.Collections.Generic;
using System.Linq;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Compiler
{
    public class Kernel<T> : IKernel<T> where T : unmanaged
    {
        public DeviceType DeviceType { get; protected set; }

        public IExpressionTree ExpressionTree => Tree;

        public IVariable<T> Output { get; protected set; }

        public IVariable<T>[] Input { get; protected set; }

        public ExpressionTree Tree { get; protected set; }

        public List<Tensor> TensorNodes => Tree.ValueNodes.Where(n => n.NodeType == ValueNodeType.TENSOR).Select(n => n.ValueAs<Tensor>()).ToList();

        public List<Tensor> InputTensors => TensorNodes.Where(t => !t.IsAssigned).ToList();

        public Tensor OutputTensor => Tree.OutputTensor;

        public Kernel(Tensor output, params Var<T>[] input)
        {
            if (!output.IsAssigned)
            { 
                throw new ArgumentException($"The output tensor {output.Label} must be assigned an input expression.");
            }
            Tree = output.Assignment.Expression.ToTree((output, output.Assignment.IndexSet));
            Input = input;
            
        }
    }
}
