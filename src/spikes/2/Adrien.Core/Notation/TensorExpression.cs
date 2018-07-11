using System;
using System.Collections.Generic;
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
        
        public TensorExpression Add(TensorExpression right) => new TensorExpression(Expression.Add(this, right));

        public TensorExpression Subtract(TensorExpression right) => new TensorExpression(Expression.Subtract(this, right));

        public TensorExpression Multiply(TensorExpression right) => new TensorExpression(Expression.Multiply(this, right));

        public TensorExpression Divide(TensorExpression right) => new TensorExpression(Expression.Divide(this, right));

        
    }
}