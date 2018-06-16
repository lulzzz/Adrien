using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Adrien.Notation
{
    public class IndexSet : Term
    {
        #region Constructors
        public IndexSet(int dim, string indexNameBase="") : base()
        {
            Indices = new SortedSet<Index>();
            for (int i = 0; i < dim; i++)
            {
                Indices.Add(new Index(this, i, GetName(i, indexNameBase)));
            }
        }

        public IndexSet(params Index[] indices) : base()
        {
            Indices = new SortedSet<Index>(indices);
        }
        #endregion

        #region Overriden members
        internal override Name DefaultNameBase { get; } = "I"; 
        internal override Expression LinqExpression => Expression.Constant(this);
        #endregion

        #region Properties
        public static PropertyInfo IndicesArrayInfo { get; } = typeof(Index).GetProperty("IndicesArray");

        public SortedSet<Index> Indices { get; protected set; }

        public int[] IndicesArray => Indices.Select(i => i.Order).ToArray();
        
        public int DimensionCount => Indices.Count;
        #endregion

        #region Methods
        public IndexExpression IndexExpression(params Index[] indices)
        {
            return Expression.MakeIndex(Expression.Constant(this), Index.OrderInfo, indices.Select(i => (Expression)i));
        }

        public static IndexSet One(out Index index1, string nameBase = "")
        {
            IndexSet s = new IndexSet(1, nameBase);
            index1 = s[0];
            return s;
        }

        public static IndexSet Two(out Index index1, out Index index2, string nameBase = "")
        {
            IndexSet s = new IndexSet(2, nameBase);
            index1 = s[0];
            index2 = s[1];
            return s;
        }

        public static IndexSet Three(out Index index1, out Index index2, out Index index3, string nameBase = "")
        {
            IndexSet s = new IndexSet(3, nameBase);
            index1 = s[0];
            index2 = s[1];
            index3 = s[2];
            return s;
        }

        public static IndexSet Four(out Index index1, out Index index2, out Index index3, out Index index4, string nameBase = "")
        {
            IndexSet s = new IndexSet(4, nameBase);
            (index1, index2, index3, index4) = s;
            return s;
        }

        #region Deconstructors
        public void Deconstruct(out Index index1, out Index index2)
        {
            ThrowIfIndicesExceedDimensions(2);
            index1 = this[0];
            index2 = this[1];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3)
        {
            ThrowIfIndicesExceedDimensions(3);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4)
        {
            ThrowIfIndicesExceedDimensions(4);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4, out Index index5)
        {
            ThrowIfIndicesExceedDimensions(5);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6)
        {
            ThrowIfIndicesExceedDimensions(6);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
            index6 = this[5];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7)
        {
            ThrowIfIndicesExceedDimensions(7);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
            index6 = this[5];
            index7 = this[6];        }
        #endregion

        protected void ThrowIfIndicesExceedDimensions(int c)
        {
            if (c > DimensionCount) throw new ArgumentOutOfRangeException("The number of indices exceeds the dimensions of this index set.");
        }
        #endregion

        #region Operators
        public Index this[int index]
        {
            get
            {
                ThrowIfIndicesExceedDimensions(index);
                return Indices.ElementAt(index); 
            }
        }

        public static implicit operator Index(IndexSet s)
        {
            s.ThrowIfIndicesExceedDimensions(1);
            return s[0];
        }

        public static implicit operator IndexSet((Index index1, Index index2) t)
        {
            return new IndexSet(t.index1, t.index2);
        }

        public static implicit operator IndexSet((Index index1, Index index2, Index index3) t)
        {
            return new IndexSet(t.index1, t.index2, t.index3);
        }

        public static implicit operator IndexSet((Index index1, Index index2, Index index3, Index index4) t)
        {
            return new IndexSet(t.index1, t.index2, t.index3, t.index4);
        }

        public static implicit operator IndexSet((Index index1, Index index2, Index index3, Index index4, Index index5) t)
        {
            return new IndexSet(t.index1, t.index2, t.index3, t.index4, t.index5);
        }

        public static implicit operator IndexSet((Index index1, Index index2, Index index3, Index index4, Index index5, Index index6) t)
        {
            return new IndexSet(t.index1, t.index2, t.index3, t.index4, t.index5, t.index6);
        }

        public static implicit operator IndexSet((Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7) t)
        {
            return new IndexSet(t.index1, t.index2, t.index3, t.index4, t.index5, t.index6, t.index7);
        }
        #endregion
    }
}
