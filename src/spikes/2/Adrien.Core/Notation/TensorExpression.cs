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

        internal override Type ExpressionType => LinqExpression.Type;
         
        public TensorExpression(Expression e) : base(GetNameFromLinqExpression(e))
        {
            LinqExpression = e;
        }

        public TensorExpression(Expression e, Tensor lhs) : this(e)
        {
            this.LHSTensor = lhs;
        }

        public static TensorExpression operator -(TensorExpression left) => left.Negate();

        public static TensorExpression operator +(TensorExpression left, TensorExpression right) => left.Add(right);

        public static TensorExpression operator -(TensorExpression left, TensorExpression right) =>
            left.Subtract(right);

        public static TensorExpression operator *(TensorExpression left, TensorExpression right) =>
            left.Multiply(right);

        public static TensorExpression operator /(TensorExpression left, TensorExpression right) => left.Divide(right);


        public virtual ExpressionTree ToTree() => 
            LHSTensor == null ? new TensorExpressionVisitor(this.LinqExpression).Tree : 
            new TensorExpressionVisitor(this.LinqExpression, LHSTensor, true).Tree;

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


        #region Dummy unary and binary methods for IAlgerba methods
        private static TensorExpression DummyUnary(Tensor l) => null;
        private static TensorExpression DummyUnary(TensorExpression l) => null;

        private static TensorExpression DummyBinary(Tensor l, Tensor r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Tensor r) => null;
        private static TensorExpression DummyBinary(Tensor l, TensorExpression r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, TensorExpression r) => null;

        private static TensorExpression DummyUnary(Scalar l) => null;  
        private static TensorExpression DummyBinary(Scalar l, Scalar r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Scalar r) => null;
        private static TensorExpression DummyBinary(Scalar l, TensorExpression r) => null;

        private static TensorExpression DummyUnary(Vector l) => null;
        private static TensorExpression DummyBinary(Vector l, Vector r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Vector r) => null;
        private static TensorExpression DummyBinary(Vector l, TensorExpression r) => null;

        private static TensorExpression DummyUnary(Matrix l) => null;
        private static TensorExpression DummyBinary(Matrix l, Matrix r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Matrix r) => null;
        private static TensorExpression DummyBinary(Matrix l, TensorExpression r) => null;

        private static TensorExpression DummyBinary(Scalar l, Vector r) => null;
        private static TensorExpression DummyBinary(Vector l, Scalar r) => null;
        private static TensorExpression DummyBinary(Scalar l, Matrix r) => null;
        private static TensorExpression DummyBinary(Matrix l, Scalar r) => null;
        private static TensorExpression DummyBinary(Matrix l, Vector r) => null;
        private static TensorExpression DummyBinary(Vector l, Matrix r) => null;
        #endregion

    }
}