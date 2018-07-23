using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

using Sawmill;
using Sawmill.Expressions;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Notation
{
    public partial class TensorExpression : Term, IAlgebra<TensorExpression, TensorExpression>
    {
        internal override Expression LinqExpression { get; }
        
        internal override Name DefaultNameBase => "tensor_expr0";

        public (IndexSet IndexSet, TensorExpression Expression) Assignment { get; protected set; }

        public bool IsAssigned => Assignment.Expression != null;

        public List<Tensor> Tensors => LinqExpression.GetConstants<Tensor>();
        
        public ExpressionTree ToTree() => new TensorExpressionVisitor(this.LinqExpression).Tree;

        public ExpressionTree ToTree((Tensor tensor, IndexSet indices) lhs) => new TensorExpressionVisitor(this.LinqExpression, lhs, true).Tree;
       
        public TensorExpression(Expression e)
        {
            LinqExpression = e;
            Name = GetNameFromLinqExpression(LinqExpression);
        }


        public static TensorExpression operator - (TensorExpression left) => left.Negate();

        public static TensorExpression operator ^ (TensorExpression left, object right) => left.Power(right);

        public static TensorExpression operator + (TensorExpression left, TensorExpression right) => left.Add(right);

        public static TensorExpression operator - (TensorExpression left, TensorExpression right) => left.Subtract(right);

        public static TensorExpression operator * (TensorExpression left, TensorExpression right) => left.Multiply(right);

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

        public TensorExpression Power(object right)
        {
            switch (right)
            {
                case TensorExpression r: return new TensorExpression(Expression.Power(this,
                    r, GetDummyBinaryMethodInfo(this, r)));
                case Tensor t:
                    return new TensorExpression(Expression.Power(this, t, GetDummyBinaryMethodInfo(this, t)));
                default:
                    Scalar s = new Scalar(right);
                    return new TensorExpression(Expression.Power(this, s, GetDummyBinaryMethodInfo(this, s)));
            }
        }


        public TensorExpression Power(int right) => new TensorExpression(Expression.Power(this,
            Expression.Constant(right), GetDummyBinaryMethodInfo(this, new Scalar(right))));

        public TensorExpression Sqrt() => new TensorExpression(Expression.Power(this, Expression.Constant(.5)));

        public TensorExpression sigma(params Index[] indices)
        {
            Array a = Array.CreateInstance(typeof(Tensor), indices.Select(i => i.Dimension).ToArray());
            return new TensorExpression(Expression.ArrayAccess(Expression.Constant(a), indices
                .Select(i => Expression.Parameter(typeof(Int32), i.Name)).ToArray()));
        }


        private static TensorExpression DummyBinary(Tensor l, Tensor r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, Tensor r) => null;
        private static TensorExpression DummyBinary(Tensor l, TensorExpression r) => null;
        private static TensorExpression DummyBinary(TensorExpression l, TensorExpression r) => null;

        private static MethodInfo GetDummyBinaryMethodInfo(TensorExpression l, TensorExpression r)
        {
            Type lt = l.GetTensorExpressionType();
            Type rt = r.GetTensorExpressionType();


            MethodInfo method = typeof(TensorExpression).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyBinary" && m.GetParameters()[0].ParameterType == lt
                && m.GetParameters()[1].ParameterType == rt).First();
            return method;
        }

        private Type GetTensorExpressionType()
        {
            if (this.LinqExpression.NodeType == ExpressionType.Constant)
            {
                return (this.LinqExpression as ConstantExpression).Type;
            }
            else if (this.LinqExpression.NodeType == ExpressionType.Index)
            {
                return (this.LinqExpression as IndexExpression).Object.Type.GetElementType();
            }
            else return typeof(TensorExpression);
        }


        [DebuggerStepThrough]
        internal void ThrowIfAlreadyAssiged()
        {
            if (Assignment.IndexSet != null)
            {
                throw new InvalidOperationException("This tensor expression variable has an existing assigment. + " +
                    $"You can only assign to a tensor expression variable once.");
            }
        }

    }
}