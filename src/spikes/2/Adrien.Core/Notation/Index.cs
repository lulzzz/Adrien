using System;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Adrien.Notation
{
    public class Index : Term, IComparable<Index>
    {
        public IndexSet Set { get; protected set; }
        public int Order { get; protected set; }
        public (int upper, int lower) Bounds { get; internal set; }
        public static PropertyInfo OrderInfo { get; } = typeof(Index).GetProperty("Order");

        internal override Expression LinqExpression => Expression.Constant(this);
        internal override Name DefaultNameBase { get; } = "i";


        public Index(IndexSet set, int order, string name) : base(name)
        {
            Set = set;
            Order = order;
        }
        
        public int CompareTo(Index i)
        {
            return this.Order.CompareTo(i.Order);
        }
        



       
    }

}
