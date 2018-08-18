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

        public List<Tensor> InputVariables => Tensors.Where(t => !(t.IsDefined || t is Dimension)).ToList();

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


        public static TensorExpression operator -(TensorExpression left) => left.Negate();

        public static TensorExpression operator +(TensorExpression left, TensorExpression right) => left.Add(right);

        public static TensorExpression operator -(TensorExpression left, TensorExpression right) =>
            left.Subtract(right);

        public static TensorExpression operator *(TensorExpression left, TensorExpression right) =>
            left.Multiply(right);

        public static TensorExpression operator /(TensorExpression left, TensorExpression right) => left.Divide(right);


        public TensorExpression Negate() => new TensorExpression(Expression.Negate(this));

        public TensorExpression Add(TensorExpression right) => new TensorExpression(Expression.Add(this, right,
            GetDummyBinaryMethodInfo<TensorExpression, TensorExpression>(this, right)));

        public TensorExpression Subtract(TensorExpression right) => new TensorExpression(Expression.Subtract(this,
            right, GetDummyBinaryMethodInfo<TensorExpression, TensorExpression>(this, right)));

        public TensorExpression Multiply(TensorExpression right) => new TensorExpression(Expression.Multiply(this,
            right, GetDummyBinaryMethodInfo<TensorExpression, TensorExpression>(this, right)));

        public TensorExpression Divide(TensorExpression right) => new TensorExpression(Expression.Divide(this, right,
            GetDummyBinaryMethodInfo<TensorExpression, TensorExpression>(this, right)));


        internal static MethodInfo GetOpMethodInfo<T>(string name, int parameters) where T : Term
        {
            MethodInfo method = typeof(TensorExpression)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(m => m.Name == name && m.GetParameters().Count() == parameters &&
                            m.GetParameters().First().ParameterType == typeof(T))
                .First();
            return method;
        }

        public static MethodInfo GetDummyUnaryMethodInfo<TType, TReturn>
            (TensorExpression l) where TType : TensorExpression where TReturn : TensorExpression
        {
            Type lt = l.TensorExpressionMethodParameterType;

            MethodInfo method = typeof(TType).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyUnary" && m.GetParameters()[0].ParameterType == lt
                                                   && m.ReturnType == typeof(TReturn)).First();
            return method;
        }

        public static MethodInfo GetDummyBinaryMethodInfo<TType, TReturn>(TensorExpression l, TensorExpression r)
            where TType : Term where TReturn : Term
        {
            Type lt = l.TensorExpressionMethodParameterType;
            Type rt = r.TensorExpressionMethodParameterType;


            MethodInfo method = typeof(TType).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyBinary" && m.GetParameters()[0].ParameterType == lt
                                                    && m.GetParameters()[1].ParameterType == rt
                                                    && m.ReturnType == typeof(TReturn)).First();
            return method;
        }

        private static TensorExpression DummyUnary(Tensor l) => null;
        private static TensorExpression DummyUnary(TensorExpression l) => null;

        private static TensorExpression DummyBinary(Tensor l, Tensor r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Tensor r) => null;
        private static TensorExpression DummyBinary(Tensor l, TensorExpression r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, TensorExpression r) => null;
        
        private Type TensorExpressionMethodParameterType
        {
            get
            {
                if ((LinqExpression is ConstantExpression ce) || (LinqExpression is IndexExpression))
                {
                    return typeof(Tensor);
                }
                else return this.GetType();
            }
        }
    }
}