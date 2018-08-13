using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

using Adrien.Expressions;
using Adrien.Trees;

namespace Adrien.Notation
{
    public partial class TensorExpression : Term, IAlgebra<TensorExpression, TensorExpression>
    {
        internal override Expression LinqExpression { get; }

        internal override Name DefaultNameBase => "tensor_expr0";

        public Tensor LHSTensor { get; protected set; }

        public IndexSet LHSIndexSet { get; protected set; }

        public List<Tensor> Tensors => LinqExpression.GetConstants<Tensor>();

        public List<Tensor> InputVariables => Tensors.Where(t => !t.IsDefined).ToList();


        public List<Index> IndexParameters => LinqExpression.GetParameters<Index>();

        public virtual ExpressionTree ToTree() => new TensorExpressionVisitor(this.LinqExpression).Tree;

        public ExpressionTree ToTree((Tensor tensor, IndexSet indices) lhs) =>
            new TensorExpressionVisitor(this.LinqExpression, lhs, true).Tree;


        public TensorExpression(Expression e) : base(GetNameFromLinqExpression(e))
        {
            LinqExpression = e;
        }

        public TensorExpression(Expression e, Tensor lhs) : this(e)
        {
            this.LHSTensor = lhs;
        }

        public TensorExpression(Expression e, Tensor lhs, IndexSet lhsIndexSet) : this(e, lhs)
        {
            this.LHSIndexSet = lhsIndexSet;
        }

        
        public static TensorExpression operator - (TensorExpression left) => left.Negate();

        public static TensorExpression operator + (TensorExpression left, TensorExpression right) => left.Add(right);

        public static TensorExpression operator - (TensorExpression left, TensorExpression right) =>
            left.Subtract(right);

        public static TensorExpression operator * (TensorExpression left, TensorExpression right) =>
            left.Multiply(right);

        public static TensorExpression operator / (TensorExpression left, TensorExpression right) => left.Divide(right);


        public TensorExpression Negate() => new TensorExpression(Expression.Negate(this));

        public TensorExpression Add(TensorExpression right) => new TensorExpression(Expression.Add(this, right,
            GetDummyBinaryMethodInfo(this, right)));

        public TensorExpression Subtract(TensorExpression right) => new TensorExpression(Expression.Subtract(this,
            right, GetDummyBinaryMethodInfo(this, right)));

        public TensorExpression Multiply(TensorExpression right) => new TensorExpression(Expression.Multiply(this,
            right, GetDummyBinaryMethodInfo(this, right)));

        public TensorExpression Divide(TensorExpression right) => new TensorExpression(Expression.Divide(this, right,
            GetDummyBinaryMethodInfo(this, right)));

        internal static MethodInfo GetOpMethodInfo<T>(string name, int parameters) where T : Term
        {
            MethodInfo method = typeof(TensorExpression)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(m => m.Name == name && m.GetParameters().Count() == parameters &&
                            m.GetParameters().First().ParameterType == typeof(T))
                .First();
            return method;
        }

        protected static MethodInfo GetDummyUnaryMethodInfo(TensorExpression l)
        {
            Type lt = l.TensorExpressionMethodParameterType;

            MethodInfo method = typeof(TensorExpression).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyUnary" && m.GetParameters()[0].ParameterType == lt).First();
            return method;
        }

        protected static MethodInfo GetDummyBinaryMethodInfo(TensorExpression l, TensorExpression r)
        {
            Type lt = l.TensorExpressionMethodParameterType;
            Type rt = r.TensorExpressionMethodParameterType;


            MethodInfo method = typeof(TensorExpression).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyBinary" && m.GetParameters()[0].ParameterType == lt
                                                    && m.GetParameters()[1].ParameterType == rt).First();
            return method;
        }

        protected static TensorExpression DummyUnary(Tensor l) => null;
        protected static TensorExpression DummyUnary(TensorExpression l) => null;

        protected static TensorExpression DummyBinary(Tensor l, Tensor r) => null;
        protected static TensorExpression DummyBinary(TensorExpression l, Tensor r) => null;
        protected static TensorExpression DummyBinary(Tensor l, TensorExpression r) => null;
        protected static TensorExpression DummyBinary(TensorExpression l, TensorExpression r) => null;
        protected static TensorExpression DummyBinary(Dimension l, TensorExpression r) => null;
        protected static TensorExpression DummyBinary(TensorExpression l, Dimension r) => null;
        protected static TensorExpression DummyBinary(Dimension l, TensorIndexExpression r) => null;
        protected static TensorExpression DummyBinary(TensorIndexExpression l, Dimension r) => null;

        private Type TensorExpressionMethodParameterType
        {
            get
            {
                if (LinqExpression is ConstantExpression ce)
                {
                    return typeof(Tensor);
                }
                else if (LinqExpression is IndexExpression ie)
                {
                    return ie.Object.Type.GetElementType();
                }
                else return typeof(TensorExpression);
            }
        }
    }
}