using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Adrien.Notation
{
#pragma warning disable CS0660

    public class Index : Term, IChild, IAlgebra<Index, DimensionExpression>, IComparable<Index>
    {
        public static PropertyInfo OrderInfo { get; } = typeof(Index).GetProperty("Order");

        public IndexType Type { get; protected set; }

        public ITerm Parent => Set;

        public IndexSet Set { get; internal set; }

        public int Order { get; internal set; }

        public int? Dimension { get; internal set; }

        public DimensionExpression DimensionExpression { get; protected set; }

        internal override Expression LinqExpression => Type == IndexType.Constant ? Expression.Constant(this) :
            DimensionExpression.LinqExpression;
       
        internal override Name DefaultNameBase { get; } = "i";

        public Index(IndexSet set, int order, int dim, string name) : base(name)
        {
            Set = set;
            Order = order;
            Dimension = dim;
            Type = IndexType.Constant;
        }

        public Index(DimensionExpression expr) : base(expr)
        {
            Type = IndexType.Expression;
            Name = GetNameFromLinqExpression(expr.LinqExpression);
            DimensionExpression = expr;
        }

        public Index(int i) : base("dim_expr" + i)
        {
            Type = IndexType.Expression;
            DimensionExpression = new DimensionExpression(Expression.Constant(i));
        }


        public static implicit operator Int32(Index i) => i.Order;

        public static DimensionExpression operator - (Index left) => left.Negate();
        
        public static DimensionExpression operator + (Index left, Index right)
            => left.Add(right);

        public static DimensionExpression operator - (Index left, Index right)
            => left.Subtract(right);

        public static DimensionExpression operator * (Index left, Index right)
            => left.Multiply(right);

        public static DimensionExpression operator / (Index left, Index right)
            => left.Divide(right);

        public DimensionExpression Negate() => new DimensionExpression(Expression.Negate(this));

        public DimensionExpression Add(Index right)
            => new DimensionExpression(Expression.Add(this, right, GetDummyBinaryMethodInfo(this, right)));

        public DimensionExpression Subtract(Index right)
            => new DimensionExpression(Expression.Subtract(this, right, GetDummyBinaryMethodInfo(this, right)));

        public DimensionExpression Multiply(Index right)
            => new DimensionExpression(Expression.Multiply(this, right, GetDummyBinaryMethodInfo(this, right)));

        public DimensionExpression Divide(Index right)
            => new DimensionExpression(Expression.Divide(this, right, GetDummyBinaryMethodInfo(this, right)));


        public Type GetIndexType()
        {
            if (Type == IndexType.Constant)
            {
                return typeof(Index);
            }
            else if (DimensionExpression.LinqExpression.NodeType == ExpressionType.Constant)
            {
                return (DimensionExpression.LinqExpression as ConstantExpression).Type;
            }
            else return typeof(DimensionExpression);
        }

        public int CompareTo(Index i)
        {
            return Order.CompareTo(i.Order);
        }

        private static Index DummyBinary(Index l, Index r) => null;

        private static Index DummyBinary(DimensionExpression l, Index r) => null;
        private static Index DummyBinary(Index l, DimensionExpression r) => null;

        private static Index DummyBinary(DimensionExpression l, int r) => null;
        private static Index DummyBinary(int l, DimensionExpression r) => null;

        private static Index DummyBinary(Index l, int r) => null;
        private static Index DummyBinary(int l, Index r) => null;

        private static MethodInfo GetDummyBinaryMethodInfo(Index l, Index r)
        {
            var lt = l.GetIndexType();
            var rt = r.GetIndexType();

            var method = typeof(Index).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == "DummyBinary" && m.GetParameters()[0].ParameterType == lt
                                                    && m.GetParameters()[1].ParameterType == rt).First();
            return method;
        }
    }

#pragma warning restore CS0660
}