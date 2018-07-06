using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Humanizer;

using Adrien.Compiler;
using Adrien.Trees;

namespace Adrien.Notation
{
    public partial class Tensor : Term, IAlgebra<Tensor>
    {
        public int[] Dimensions { get; protected set; }

        public int Rank => Dimensions.Length;

        public (IndexSet IndexSet, TensorExpression Expression) Assignment { get; protected set; }

        public bool IsAssigned => Assignment.IndexSet != null;

        internal override Expression LinqExpression => this.IsAssigned ? this.Assignment.Expression.LinqExpression : Expression.Constant(this, typeof(Tensor));

        internal override Name DefaultNameBase { get; } = "A";


        public Tensor(params int[] dim) : base("A")
        {
            Dimensions = dim;
        }

        public Tensor(string name, params int [] dim) : base(name)
        {
            Dimensions = dim;
        }

        public Tensor(string name, string indexNameBase, out IndexSet I, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(indexNameBase, dim);
        }

        
        
        public static implicit operator TensorExpression(Tensor t)
        {
            return new TensorExpression(t.LinqExpression);
        }

        public static implicit operator ExpressionTree(Tensor t)
        {
            if (t.IsAssigned)
            {
                return t.Assignment.Expression.ToTree((t, t.Assignment.IndexSet));
            }
            else
            {
                return new TensorExpression(t.LinqExpression).ToTree();
            }
        }
        public static Tensor operator - (Tensor left)
        {
            string name = "Negate_" + left.Name;
            return new Tensor(name) { Assignment = (new IndexSet(name), (-(TensorExpression)left)) };
        }
        public static Tensor operator + (Tensor left, Tensor right)
        {
            string name = "Add_" + left.Name + "_" + right.Name;
            return new Tensor(name) { Assignment = (new IndexSet(name), ((TensorExpression) left + (TensorExpression) right)) };
        }

        public static Tensor operator - (Tensor left, Tensor right)
        {
            string name = "Sub_" + left.Name + "_" + right.Name;
            return new Tensor(name) { Assignment = (new IndexSet(name), ((TensorExpression)left - (TensorExpression)right)) };
        }

        public static Tensor operator * (Tensor left, Tensor right)
        {
            string name = "Mul_" + left.Name + "_" + right.Name;
            return new Tensor(name) { Assignment = (new IndexSet(name), ((TensorExpression)left * (TensorExpression)right)) };
        }

        public static Tensor operator / (Tensor left, Tensor right)
        {
            string name = "Div_" + left.Name + "_" + right.Name;
            return new Tensor(name) { Assignment = (new IndexSet(name), ((TensorExpression)left / (TensorExpression)right)) };
        }


        public Tensor Negate() => - this;

        public Tensor Add(Tensor right) => this + right;

        public Tensor Subtract(Tensor right) => this - right;

        public Tensor Multiply(Tensor right) => this * right;

        public Tensor Divide(Tensor right) => this / right;

        public Tensor With(out Tensor with)
        {
            with = new Tensor(this.GenerateName(1, this.Name), this.Dimensions);
            return this;
        }

        public Tensor With(out Tensor with, params int[] dim)
        {
            with = new Tensor(this.GenerateName(1, this.Name), dim);
            return this;
        }

        public Var<T> Var<T>(Array array) where T : unmanaged => new Var<T>(this, array);

        public static string RankToTensorName(int rank)
        {
            string[] names = rank.ToWords().Split('-');
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = char.ToUpper(names[i][0]) + names[i].Substring(1);
            }
            return string.Join("", names);
        }

        [DebuggerStepThrough]
        internal void ThrowIfAlreadyAssiged()
        {
            if (Assignment.IndexSet != null)
            {
                throw new InvalidOperationException("This tensor variable has an existing assigment. You can only assign to a tensor variable once.");
            }
        }

        [DebuggerStepThrough]
        internal void ThrowIfIndicesExceedRank(int c)
        {
            if (Rank < c) throw new ArgumentOutOfRangeException("The number of indices exceeds the dimensions of this tensor.");
        }
    }
}
