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

        public IVariableShape Output { get; protected set; }

        public IReadOnlyList<IVariableShape> Input { get; protected set; }

        public ExpressionTree Tree { get; protected set; }

        public IReadOnlyList<Tensor> Tensors => Tree.Root.DescendantsAndSelf().OfType<ValueNode>()
            .Where(n => n.NodeType == ValueNodeType.TENSOR)
            .Distinct()
            .Select(n => n.ValueAs<Tensor>())
            .ToList();

        public IReadOnlyList<Tensor> InputTensors => Tensors.Where(t => t.Label != OutputTensor.Name.Label).ToList();

        public Tensor OutputTensor => Tree.OutputTensor;

        public ICompiler Compiler { get; protected set; }

        public IRunnable<T> CompilerResult { get; protected set; }

        public bool CompileSuccess { get; protected set; }

        public bool CompileBeforeRun { get; set; }

        public Func<Memory<T>[], Var<T>> Func
        {
            get
            {
                if (CompileBeforeRun || !CompileSuccess)
                {
                    Compile();
                }
                ThrowIfNotCompileSuccess();
                return new Func<Memory<T>[], Var<T>>((input) =>
                {   
                    CompilerResult.Run();
                    return null;
                    //return new Var<T>(OutputTensor, output);
                });
            }
        }

        public Kernel(Tensor output)
        {
            if (!output.IsAssigned)
            {
                throw new ArgumentException
                    ($"The output tensor {output.Label} must be assigned an input expression.");
            }
            Tree = output.Assignment.Expression.ToTree((output, output.Assignment.IndexSet));
            Input = InputTensors;
            Output = output;
        }

        public Kernel(ICompiler compiler, Tensor output, DeviceType deviceType = DeviceType.CPU) : this(output)
        {
            Compiler = compiler;
            DeviceType = deviceType;
        }

        
        public IVariableShape this[int index]
        {
            get
            {
                if (index < 0 || index > Input.Count() - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return Input[index];
                }
            }    
        }

        public IVariableShape this[Tensor index]
        {
            get => Input.SingleOrDefault(t => t.Label == index.Name) ?? 
                throw new ArgumentException($"The kernel does not contain an input variable bound to tensor " 
                    + $"{index.Label}");   
        }

        public bool Compile()
        {
            CompileSuccess = Compiler.Compile(this, out IRunnable<T> result);
            if (CompileSuccess)
            {
                CompilerResult = result;
            }
            return CompileSuccess;
        }

        protected void ThrowIfNotCompileSuccess()
        {
            if (!CompileSuccess)
            {
                throw new InvalidOperationException("The kernel was not compiled successfully..");
            }
        }
    }
}
