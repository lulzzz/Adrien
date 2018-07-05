using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Adrien.Notation
{
    public class IndexSet : Term, IEnumerable<ITerm>
    {
        public static PropertyInfo IndicesArrayInfo { get; } = typeof(Index).GetProperty("IndicesArray");

        public SortedSet<Index> Indices { get; protected set; }

        public int DimensionCount => Indices.Count;
        
        internal override Name DefaultNameBase { get; } = "I";

        internal override Expression LinqExpression => Expression.Constant(this);
        

        public IndexSet(string indexNameBase="", params int[] dim) : base()
        {
            Indices = new SortedSet<Index>();
            for (int i = 0; i < dim.Length; i++)
            {
                Indices.Add(new Index(this, i, dim[i], GenerateName(i, indexNameBase)));
            }
            this.Name = dim.Length > 0 ? Indices.Select(i => i.Name).Aggregate((a, b) => a + b) : new Name(indexNameBase);
        }

        public IndexSet(params Index[] indices) : base()
        {
            Indices = new SortedSet<Index>(indices);
            this.Name = Indices.Select(i => i.Name).Aggregate((a, b) => a + b);
            foreach(Index index in indices)
            {
                index.Set = this;
            }
        }
        
        
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


        public IEnumerator<ITerm> GetEnumerator()
        {
            foreach (Index i in Indices)
            {
                yield return (i as ITerm);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this.GetEnumerator();

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

        protected static void ThrowIfIndicesFromDifferentIndexSet(params Index[] indices)
        {
            IndexSet set = indices[0].Set;
            if (!indices.All(i => i.Set == set))
            {
                throw new InvalidOperationException("These indices are not from the same index set.");
            }
        }
    }
}
