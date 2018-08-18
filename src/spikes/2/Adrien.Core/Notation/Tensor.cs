using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Humanizer;
using Adrien.Compiler;
using Adrien.Expressions;
using Adrien.Math;
using Adrien.Trees;

namespace Adrien.Notation
{
    public partial class Tensor : Term, IAlgebra<Tensor, TensorExpression>, ITermShape
    {
        public int[] Dimensions { get; protected set; }

        public int[] Strides { get; protected set; }

        public Dimensions Dim { get; protected set; }

        public Dimension[] Axes => Dim.ToArray();

        public int Rank => Dimensions.Length;

        public int ElementCount
        {
            get
            {
                var n = 1;
                for (int i = 0; i < Dimensions.Length; i++)
                {
                    n *= Dimensions[i];
                }

                return n;
            }
        }

        public (IndexSet IndexSet, TensorContraction Expression) ContractionDefinition { get; protected set; }

        public TensorExpression  ElementwiseDefinition { get; protected set; }

#pragma warning disable IDE1006
        public TensorExpression def
        {
            get => IsDefined ? IsElementwiseDefined ? ElementwiseDefinition : ContractionDefinition.Expression : null;
            set
            {
                if (value is TensorIndexExpression)
                {
                    ContractionDefinition = (null, new TensorContraction((TensorIndexExpression)value, this, null));
                }
                else
                {
                    ElementwiseDefinition = new TensorExpression(value, this);
                }
            }
        }
#pragma warning restore IDE1006

        public bool IsDefined => ContractionDefinition.Expression != null || ElementwiseDefinition != null;

        public bool IsElementwiseDefined => ElementwiseDefinition != null;

        public bool IsContractionDefined => ContractionDefinition.Expression != null;

        internal override Expression LinqExpression => IsDefined
           ? IsContractionDefined
               ? ContractionDefinition.Expression.LinqExpression
               : ElementwiseDefinition.LinqExpression
           : Expression.Constant(this, typeof(Tensor));

        internal override Name DefaultNameBase { get; } = "A";

        protected (Tensor tensor, int index)? GeneratorContext { get; set; }

        protected Tensor(string name) : base(name) { }

        public Tensor(string name, params int[] dim) : base(name)
        {
            if (dim == null || dim.Length == 0)
            {
                throw new ArgumentException("The number of dimensions must be at least 1.");
            }

            Dimensions = dim;
            Strides = StridesInElements(Dimensions);
            Dim = new Dimensions(this);
        }

        public Tensor(params int[] dim) : this("A", dim)
        {
        }

        public Tensor(string name, string indexNameBase, out IndexSet I, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(this, indexNameBase, dim);
        }

        public Tensor(ITermShape shape) : this(shape.Label, shape.Dimensions) {}


        public TensorIndexExpression this[IndexSet I]
        {
            get
            {
                ThrowIfIndicesExceedRank(1);

                int[] tdim = new int[I.Indices.Count];
                int[] tidx = new int[I.Indices.Count];
                for (int i = 0; i < tdim.Length; i++)
                {
                    tdim[i] = 1;
                }

                Array t = Array.CreateInstance(typeof(Tensor), tdim);
                t.SetValue(this, tidx);
                Expression[] e = I.Indices.Select(i => Expression.Parameter(typeof(int), i.Name)).ToArray();
                return new TensorIndexExpression(Expression.ArrayAccess(Expression.Constant(t), e));
            }
            set
            {
                ThrowIfAlreadyAssiged();
                if (value is TensorContraction && value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (I, value as TensorContraction);
                }
                else if (value is TensorIndexExpression)
                {
                    ContractionDefinition = (I, new TensorContraction(Math.Sum(value), this, I));
                }
            }
        }

        public Dimension this[int axis]
        {
            get
            {
                return this.Axes[axis];
            }
        }

        public static implicit operator TensorExpression(Tensor t)
        {
            if (t.IsElementwiseDefined)
            {
                return t.ElementwiseDefinition;
            }
            else
            {
                return new TensorExpression(Expression.Constant(t));
            }
        }

        public static implicit operator TensorIndexExpression(Tensor t)
        {
            if (t.IsContractionDefined)
            {
                return t.ContractionDefinition.Expression;
            }
            else
            {
                throw new InvalidCastException($"Tensor {t.Label} is not defined as a contraction.");
            }
        }

        public static implicit operator Tensor(TensorIndexExpression expr)
        {
            if (expr.LinqExpression is IndexExpression && expr.LinqExpression.Type == typeof(Tensor))
            {
                return expr.Tensors.Single();
            }
            else
            {
                throw new InvalidCastException("This tensor index expression cannot be cast to a tensor.");
            }
        }
        
        public static explicit operator Tensor(TensorExpression e)
        {
            if (e.LinqExpression is ConstantExpression ce && (ce.Type == typeof(Tensor) || ce.Type.BaseType == 
                typeof(Tensor)))
            {
                return (Tensor)ce.Value;
            }
            else if (e.LHSTensor != null)
            {
                return e.LHSTensor;
            }
            else throw new InvalidCastException("This tensor expression is not a tensor variable or definition.");
        }

        public static implicit operator ExpressionTree(Tensor t)
        {
            if (t.IsContractionDefined)
            {
                return t.ContractionDefinition.Expression.ToTree((t, t.ContractionDefinition.IndexSet));
            }
            else if (t.IsElementwiseDefined)
            {
                return t.ElementwiseDefinition.ToTree((t, null));
            }
            else
            {
                return new TensorExpression(t.LinqExpression).ToTree();
            }
        }

        public static TensorExpression operator -(Tensor left) => left.Negate();

        public static TensorExpression operator +(Tensor left, Tensor right) => left.Add(right);

        public static TensorExpression operator -(Tensor left, Tensor right) => left.Subtract(right);

        public static TensorExpression operator *(Tensor left, Tensor right) => left.Multiply(right);

        public static TensorExpression operator /(Tensor left, Tensor right) => left.Divide(right);


        public static int[] StridesInElements(int[] dim)
        {
            var strides = new int[dim.Length];
            float s = 1;
            for (int i = 0; i < dim.Length; i++)
            {
                if (dim[i] > 0)
                {
                    s *= Convert.ToSingle(dim[i]);
                }
            }

            for (int i = 0; i < dim.Length; i++)
            {
                if (dim[i] > 0)
                {
                    s /= Convert.ToSingle(dim[i]);
                    strides[i] = Convert.ToInt32(s);
                }
            }

            return strides;
        }

        public static int[] StridesInBytes<T>(int[] dim)
        {
            var strides = StridesInElements(dim);
            for (int i = 0; i < strides.Length; i++)
            {
                strides[i] *= Unsafe.SizeOf<T>();
            }

            return strides;
        }

        public TensorExpression Negate() => -(TensorExpression) this;

        public TensorExpression Add(Tensor right) => (TensorExpression) this + right;

        public TensorExpression Subtract(Tensor right) => (TensorExpression) this - right;

        public TensorExpression Multiply(Tensor right) => (TensorExpression) this * right;

        public TensorExpression Divide(Tensor right) => (TensorExpression) this / right;

        public Tensor With(out Tensor with)
        {
            GeneratorContext = GeneratorContext ?? ((this, 1));
            with = new Tensor(GenerateName(GeneratorContext.Value.index, Name), Dimensions);
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor;
        }

        public Tensor With(out Tensor with, string name)
        {
            GeneratorContext = GeneratorContext ?? (this, 1);
            with = new Tensor(name, Dimensions);
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor;
        }

        public Tensor With(out Tensor with, params int[] dim)
        {
            GeneratorContext = GeneratorContext ?? (this, 1);
            if (dim.Length != GeneratorContext.Value.tensor.Dimensions.Length)
            {
                throw new ArgumentException($"The rank of the new tensor must be the same as the original: " +
                                            $"{dim.Length}.");
            }

            with = new Tensor(GenerateName(GeneratorContext.Value.index, Name), dim);
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor;
        }

        public Tensor With(out Tensor with, string name, params int[] dim)
        {
            GeneratorContext = GeneratorContext ?? (this, 1);
            if (dim.Length != GeneratorContext.Value.tensor.Dimensions.Length)
            {
                throw new ArgumentException($"The rank of the new tensor must be the same as the original: " +
                                            $"{dim.Length}.");
            }

            with = new Tensor(name, dim);
            GeneratorContext = (GeneratorContext.Value.tensor, GeneratorContext.Value.index + 1);
            return GeneratorContext.Value.tensor;
        }

        public ExpressionTree ToTree() => IsDefined
            ? IsContractionDefined
                ? ContractionDefinition.Expression.ToTree((this, ContractionDefinition.IndexSet))
                : ElementwiseDefinition.ToTree((this, null))
            : new TensorExpression(LinqExpression).ToTree();

        public Var<T> Var<T>(Array array) where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
            => new Var<T>(this, array);

        public Var<T> Var<T>(params T[] data) where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
            => new Var<T>(this, data);

        public Var<T> Var<T>() where T : unmanaged, IEquatable<T>, IComparable<T>, IConvertible
            => new Var<T>(this, Array.CreateInstance(typeof(T), Dimensions));

        /// <summary> Only intended for the C# templating process. </summary>
        public static string RankToTensorName(int rank)
        {
            var names = rank.ToWords().Split('-');
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = char.ToUpper(names[i][0]) + names[i].Substring(1);
            }

            return string.Join("", names);
        }

        public IndexSet AxesToIndices(params int[] axes)
        {
            if (axes.Length == 0)
            {
                axes = new[] {Rank - 1};
            }
            else if (axes.Length > Dimensions.Length)
            {
                throw new ArgumentException("The number of axes specified exceeds the rank of this tensor.");
            }
            else if (axes.Length == 1 && axes[0] < 0)
            {
                axes[0] = Rank + axes[0];
            }
            else
            {
                for (int i = 0; i < axes.Length; i++)
                {
                    if (axes[i] < 0)
                    {
                        axes[i] = axes.Length + axes[i];
                    }
                }
            }

            axes = axes.OrderBy(a => a).ToArray();
            string nb = Label.ToLower();
            Index[] indices = Dimensions.Select((o, d) => new Index(null, o, d, nb + o.ToString())).ToArray();
            IndexSet S = new IndexSet(this, indices);
            return S;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Dimensions.Length; i++)
            {
                yield return Dimensions[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [DebuggerStepThrough]
        internal void ThrowIfAlreadyAssiged()
        {
            if (IsDefined)
            {
                throw new InvalidOperationException("This tensor variable has an existing assigment. + " +
                                                    $"You can only assign to a tensor variable once.");
            }
        }

        [DebuggerStepThrough]
        internal void ThrowIfIndicesExceedRank(int c)
        {
            if (Rank < c)
                throw new ArgumentOutOfRangeException("The number of indices exceeds the number of dimensions of " +
                                                      $"this tensor.");
        }

        [DebuggerStepThrough]
        internal void ThrowIfAxisExceedRank(int a)
        {
            if (Rank < a)
                throw new ArgumentOutOfRangeException("The specified axis exceeds the rank of this tensor.");
        }
    }
}