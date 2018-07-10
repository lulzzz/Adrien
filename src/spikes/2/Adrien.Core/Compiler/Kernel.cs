using System;
using System.Collections.Generic;
using System.Linq;

using Sawmill;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Compiler
{
    public class Kernel<T> : IKernel<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public DeviceType DeviceType { get; protected set; }

        public IExpressionTree ExpressionTree => Tree;

        public IVariable<T> Output { get; protected set; }

        public IReadOnlyList<IVariable<T>> Input { get; protected set; }

        public ExpressionTree Tree { get; protected set; }

        public IReadOnlyList<Tensor> Tensors => Tree.Root.DescendantsAndSelf().OfType<ValueNode>()
            .Where(n => n.NodeType == ValueNodeType.TENSOR).Distinct().Select(n => n.ValueAs<Tensor>()).ToList();

        public IReadOnlyList<Tensor> InputTensors => Tensors.Where(t => t.Label != OutputTensor.Name.Label).ToList();

        public Tensor OutputTensor => Tree.OutputTensor;


        public Kernel(Tensor output, DeviceType deviceType = DeviceType.CPU, params Var<T>[] input)
        {
            if (!output.IsAssigned)
            { 
                throw new ArgumentException($"The output tensor {output.Label} must be assigned an input expression.");
            }
            if (input.Length != InputTensors.Count) 
            {
                throw new ArgumentException($"This kernel has {InputTensors.Count} input tensors but only " + 
                    $"{input.Length} input variables were specified as arguments.");                               
            }
            DeviceType = deviceType;
            Tree = output.Assignment.Expression.ToTree((output, output.Assignment.IndexSet));
            Input = input;
        }

        public Kernel(Tensor output, DeviceType deviceType = DeviceType.CPU)
        {
            if (!output.IsAssigned)
            {
                throw new ArgumentException
                    ($"The output tensor {output.Label} must be assigned an input expression.");
            }
            DeviceType = deviceType;
            Tree = output.Assignment.Expression.ToTree((output, output.Assignment.IndexSet));
            Input = InputTensors.Select(t => t.Var(new T[t.NumberofElements]) as IVariable<T>).ToList();
        }

        public IVariable<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= Input.Count())
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return Input[index];
                }
            }    
        }

        public IVariable<T> this[Tensor index]
        {
            get => Input.SingleOrDefault(t => t.Name == index.Name) ?? 
                throw new ArgumentException($"The kernel does not contain an input variable bound to tensor " 
                    + $"{index.Label}");
            
        }
    }
}
