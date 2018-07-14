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

        public IVariableShape OutputShape { get; protected set; }

        public IReadOnlyList<IVariableShape> InputShapes { get; protected set; }

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

        public Func<Var<T>[], Var<T>> Func
        {
            get
            {
                if (CompileBeforeRun || !CompileSuccess)
                {
                    Compile();
                }
                ThrowIfNotCompileSuccess();

                return new Func<Var<T>[], Var<T>>((inputData) =>
                {
                    var output = OutputTensor.Var(new T[OutputTensor.NumberofElements]);
                    if (CompilerResult.Run(inputData.ToList(), output))
                    {
                        return output;
                    }
                    else
                    {
                        return null;
                    }
                    
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
            InputShapes = InputTensors;
            OutputShape = output;
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
                if (index < 0 || index > InputShapes.Count() - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return InputShapes[index];
                }
            }    
        }

        public IVariableShape this[Tensor index]
        {
            get => InputShapes.SingleOrDefault(t => t.Label == index.Name) ?? 
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
