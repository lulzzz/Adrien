using System;
using System.Collections.Generic;
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
    public class TensorExpression : Term, IAlgebra<TensorExpression, TensorExpression>
    {
        internal override Expression LinqExpression { get; }
        
        internal override Name DefaultNameBase => "tensor_expr0";

        public List<Tensor> Tensors => LinqExpression.GetConstants<Tensor>();
        
        public ExpressionTree ToTree() => new TensorExpressionVisitor(this.LinqExpression, null, true).Tree;

        public ExpressionTree ToTree((Tensor tensor, IndexSet indices) output) => new TensorExpressionVisitor(this.LinqExpression, output, true).Tree;
       
        public TensorExpression(Expression e)
        {
            LinqExpression = e;
            Name = GetNameFromLinqExpression(LinqExpression);
        }


        public static TensorExpression operator - (TensorExpression left) => left.Negate();

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

        private static TensorExpression DummyBinary(Tensor l, Tensor r) => null;

        private static TensorExpression DummyBinary(TensorExpression l, Tensor r) => null;
        private static TensorExpression DummyBinary(Tensor l, TensorExpression r) => null;

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
            else return typeof(TensorExpression);

        }
    }
}