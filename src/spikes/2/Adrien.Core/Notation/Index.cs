using System;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Adrien.Notation
{
    #pragma warning disable CS0660

    public class Index : Term, IChild, IAlgebra<Index, TensorIndexExpression>, IComparable<Index>, IEquatable<Index>
    {
        public static PropertyInfo OrderInfo { get; } = typeof(Index).GetProperty("Order");

        public IndexType Type { get; protected set; }

        public ITerm Parent => Set;

        public IndexSet Set { get; internal set; }

        public int Order { get; internal set; }

        public int Dimension { get; internal set; }

        public TensorIndexExpression IndexExpression { get; protected set; }

        internal override Expression LinqExpression => Type == IndexType.Constant ? Expression.Constant(this) :
            IndexExpression.LinqExpression;
       
        internal override Name DefaultNameBase { get; } = "i";

        
        public Index(IndexSet set, int order, int dim, string name) : base(name)
        {
            Set = set;
            Order = order;
            Dimension = dim;
            Type = IndexType.Constant;
        }

        public Index(TensorIndexExpression expr)
        { 
            Type = IndexType.Expression;
            Name = GetNameFromLinqExpression(expr.LinqExpression);
            IndexExpression = expr;
        }

        public Index(int i)
        {
            Name = "int_" + i.ToString();
            Type = IndexType.Expression;
            IndexExpression = new TensorIndexExpression(Expression.Constant(i));
        }
        
        public static implicit operator Index(Int32 i) => new Index(i);

        public static TensorIndexExpression operator - (Index left) => left.Negate();
        
        public static TensorIndexExpression operator + (Index left, Index right)
            => left.Add(right);

        public static TensorIndexExpression operator - (Index left, Index right)
            => left.Subtract(right);

        public static TensorIndexExpression operator * (Index left, Index right)
            => left.Multiply(right);

        public static TensorIndexExpression operator / (Index left, Index right)
            => left.Divide(right);

        public static TensorIndexExpression operator  == (Index left, Index right)
            => left.Equal(right);

        public static TensorIndexExpression operator != (Index left, Index right)
            => left.NotEqual(right);

        public TensorIndexExpression Negate() => new TensorIndexExpression(Expression.Negate(this));

        public TensorIndexExpression Add(Index right)
            => new TensorIndexExpression(Expression.Add(this, right, GetDummyBinaryMethodInfo(this, right)));

        public TensorIndexExpression Subtract(Index right)
            => new TensorIndexExpression(Expression.Subtract(this, right, GetDummyBinaryMethodInfo(this, right)));

        public TensorIndexExpression Multiply(Index right)
            => new TensorIndexExpression(Expression.Multiply(this, right, GetDummyBinaryMethodInfo(this, right)));

        public TensorIndexExpression Divide(Index right)
            => new TensorIndexExpression(Expression.Divide(this, right, GetDummyBinaryMethodInfo(this, right)));

        public TensorIndexExpression Equal(Index right)
            => new TensorIndexExpression(Expression.Equal(this, right,false, GetDummyBinaryMethodInfo(this, right)));

        public TensorIndexExpression NotEqual(Index right)
            => new TensorIndexExpression(Expression.NotEqual(this, right, false, GetDummyBinaryMethodInfo(this, 
                right)));

        public bool Equals(Index i) => ReferenceEquals(this, i);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public Type GetIndexType()
        {
            if (Type == IndexType.Constant)
            {
                return typeof(Index);
            }
            else if (IndexExpression.LinqExpression.NodeType == ExpressionType.Constant)
            {
                return (IndexExpression.LinqExpression as ConstantExpression).Type;
            }
            else return typeof(TensorIndexExpression);
            
        }

        public int CompareTo(Index i)
        {
            return this.Order.CompareTo(i.Order);
        }

        private static Index DummyBinary(Index l, Index r) => null;

        private static Index DummyBinary(TensorIndexExpression l, Index r) => null;
        private static Index DummyBinary(Index l, TensorIndexExpression r) => null;

        private static Index DummyBinary(TensorIndexExpression l, int r) => null;
        private static Index DummyBinary(int l, TensorIndexExpression r) => null;

        private static Index DummyBinary(Index l, int r) => null;
        private static Index DummyBinary(int l, Index r) => null;

        private static MethodInfo GetDummyBinaryMethodInfo(Index l, Index r)
        {
            Type lt = l.GetIndexType();
            Type rt = r.GetIndexType();
            

            MethodInfo method = typeof(Index).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyBinary" && m.GetParameters()[0].ParameterType == lt
                && m.GetParameters()[1].ParameterType == rt).First();
            return method;
        }

    }

    #pragma warning restore CS0660

}
