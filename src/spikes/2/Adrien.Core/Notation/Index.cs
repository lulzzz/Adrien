using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    public class Index : Term
    {
        #region Constructors
        public Index(IndexSet set, int order, string name) : base(name)
        {
            Set = set;
            Order = order;
        }
        #endregion

        #region Override members
        internal override Expression LinqExpression => Expression.Constant(this);
        #endregion

        #region Overriden members
        internal override Name DefaultNameBase { get; } = "i";
        #endregion

        #region Properties
        public IndexSet Set { get; protected set; }
        public int Order { get; protected set; }
        public (int upper, int lower) Bounds { get; internal set; }

        #region Names
        public static Name a = "a";
        public static Name b= "b";
        public static Name c = "c";
        public static Name d = "d";
        public static Name e = "e";
        public static Name f = "f";
        public static Name g = "g";
        public static Name h = "h";
        public static Name i = "i";
        public static Name j = "j";
        public static Name k = "k";
        public static Name l = "l";
        public static Name m = "m";
        public static Name n = "n";
        public static Name o = "o";
        public static Name p = "p";
        public static Name q = "q";
        public static Name r = "r";
        public static Name s = "s";
        public static Name t = "t";
        public static Name u = "u";
        public static Name v = "v";
        public static Name w = "w";
        public static Name x = "x";
        public static Name y = "y";
        public static Name z = "z";
        #endregion

        #endregion
    }

}
