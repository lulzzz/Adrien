using System;
using System.Collections.Generic;
using System.Linq;

using Sawmill;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Compiler
{
    public partial class Kernel<T> : IKernel<T> where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
    {
        public DeviceType DeviceType { get; protected set; }

        public IExpressionTree ExpressionTree => Tree;

        public IVariableShape OutputShape { get; set; }

        public IReadOnlyList<IVariableShape> InputShapes { get; protected set; }

        public ExpressionTree Tree { get; protected set; }

        public IReadOnlyList<Tensor> Tensors => Tree.Root.DescendantsAndSelf()
            .OfType<ValueNode>()
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
                if (!CompileSuccess)
                {
                    return null;
                }
                if (CompileBeforeRun || !CompileSuccess)
                {
                    Compile();
                }
                

                return new Func<Var<T>[], Var<T>>((input) =>
                {
                    if (input.Length != this.InputShapes.Count)
                    {
                        throw new ArgumentException($"The kernel has {InputShapes.Count} input parameters but "
                            + $"{input.Length} arguments were used.");
                    }
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i].Tensor == null)
                        {
                            input[i].Tensor = InputTensors[i];
                        }
                    }
                    var output = OutputTensor.Var(new T[OutputTensor.NumberofElements]);
                    if (CompilerResult.Run(output, input) == RunStatus.Success)
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

        protected IVariableShape GeneratedOutputShape { get; set; }

        public Kernel(Tensor output)
        {
            if (!output.IsAssigned)
            {
                throw new ArgumentException
                    ($"The output tensor {output.Label} must be assigned an input expression.");
            }
            else if (output.IsElementwiseAssigned)
            {
                Tree = output.ElementwiseAssignment.Expression.ToTree((output, null));
            }
            else
            {
                Tree = output.IndexedAssignment.Expression.ToTree((output, output.IndexedAssignment.IndexSet));
            }
            
            InputShapes = InputTensors;
            OutputShape = output;
        }

        public Kernel(Tensor output, ICompiler compiler, DeviceType deviceType = DeviceType.CPU) : this(output)
        {
            Compiler = compiler;
            DeviceType = deviceType;
        }

        public Kernel(TensorExpression expr)
        {
            Tree = expr.ToTree();
            InputShapes = InputTensors;

        }

        public Kernel(Tensor output, TensorExpression expr)
        {
            Tree = expr.ToTree((output, null));
            InputShapes = InputTensors;
            OutputShape = output;
        }


        public Kernel(Tensor output, TensorExpression expr, ICompiler compiler, DeviceType deviceType = DeviceType.CPU) 
            : this(output, expr)
        {
            Compiler = compiler;
            DeviceType = deviceType;
        }

        public Kernel(TensorExpression expr, ICompiler compiler, DeviceType deviceType = DeviceType.CPU)
            : this(expr)
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
