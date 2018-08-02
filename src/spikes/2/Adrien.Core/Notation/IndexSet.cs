using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Adrien.Notation
{
    public class IndexSet : Term, IChild, IEnumerable<ITerm>
    {
        public static PropertyInfo IndicesArrayInfo { get; } = typeof(Index).GetProperty("IndicesArray");

        public SortedSet<Index> Indices { get; protected set; }

        public Tensor Tensor { get; protected set; }

        public ITerm Parent => Tensor;

        public int DimensionCount => Indices.Count;

        internal override Name DefaultNameBase { get; } = "I";

        internal override Expression LinqExpression => Expression.Constant(this);

        public IndexSet(Tensor parent, string indexNameBase = "", params int[] dim)
        {
            Indices = new SortedSet<Index>();
            for (var i = 0; i < dim.Length; i++)
            {
                Indices.Add(new Index(this, i, dim[i], GenerateName(i, indexNameBase)));
            }

            Name = dim.Length > 0
                ? Indices.Select(i => i.Name).Aggregate((a, b) => a + b)
                : new Name(indexNameBase);
            this.Tensor = parent;
        }

        public IndexSet(Tensor parent, params Index[] indices)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i].Order = i;
            }

            Indices = new SortedSet<Index>(indices);
            Name = Indices.Select(i => i.Name).Aggregate((a, b) => a + b);
            foreach (Index index in indices)
            {
                index.Set = this;
            }
            this.Tensor = parent;
        }

        public Index this[int index]
        {
            get
            {
                ThrowIfIndicesExceedDimensions(index);
                return Indices.ElementAt(index);
            }
        }

        public IEnumerator<ITerm> GetEnumerator()
        {
            foreach (var i in Indices)
            {
                yield return (i as ITerm);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

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

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4,
            out Index index5)
        {
            ThrowIfIndicesExceedDimensions(5);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4,
            out Index index5, out Index index6)
        {
            ThrowIfIndicesExceedDimensions(6);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
            index6 = this[5];
        }

        public void Deconstruct(out Index index1, out Index index2, out Index index3, out Index index4,
            out Index index5, out Index index6, out Index index7)
        {
            ThrowIfIndicesExceedDimensions(7);
            index1 = this[0];
            index2 = this[1];
            index3 = this[2];
            index4 = this[3];
            index5 = this[4];
            index6 = this[5];
            index7 = this[6];
        }
        #endregion

        protected void ThrowIfIndicesExceedDimensions(int c)
        {
            if (c > DimensionCount)
                throw new ArgumentOutOfRangeException(
                    "The number of indices exceeds the dimensions of this index set.");
        }

        protected static void ThrowIfIndicesFromDifferentIndexSet(params Index[] indices)
        {
            var set = indices[0].Set;
            if (indices.Any(i => i.Set != set))
            {
                throw new InvalidOperationException("These indices are not from the same index set.");
            }
        }
    }
}