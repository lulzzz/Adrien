using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
namespace Adrien.Notation
{
    public class Tensor : Term
    {
        public int[] Dimensions { get; protected set; }

        public int Rank => Dimensions.Length;

        public (IndexSet IndexSet, TensorExpression Expression) Assignment { get; protected set; }

        public bool IsAssigned => Assignment.IndexSet != null;

        internal override Expression LinqExpression => Expression.Constant(this);

        internal override Name DefaultNameBase { get; } = "A";

        public Tensor(params int[] dim) : base("T")
        {
            Dimensions = dim;
        }

        public Tensor(string name, params int [] dim) : base(name)
        {
            Dimensions = dim;
        }

        public Tensor(string name, out IndexSet I, string indexNameBase, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(dim.Length, indexNameBase);
        }

        public Tensor(string name, string indexNameBase, out IndexSet I, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(dim.Length, indexNameBase);
        }

        #region Indexers
        public static implicit operator TensorExpression(Tensor t)
        {
            return new TensorExpression(t.LinqExpression);
        }

        public TensorExpression this[IndexSet indexSet]
        {
            get
            {
                if (Rank <= indexSet.DimensionCount)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[] { }), null,
                        new Expression[] { Expression.Parameter(typeof(int), indexSet.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (indexSet, value);
            }
        }

        public TensorExpression this[Index index1]
        {
            get
            {
                if (Rank > 0)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1), value);
            }
        }

        public TensorExpression this[Index index1, Index index2]
        {
            get
            {
                if (Rank > 1)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name), Expression.Parameter(typeof(int), index2.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2), value);
            }
        }

        public TensorExpression this[Index index1, Index index2, Index index3]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name),
                        Expression.Parameter(typeof(int), index2.Name), Expression.Parameter(typeof(int), index3.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2, index3), value);
            }
        }

        public TensorExpression this[Index index1, Index index2, Index index3, Index index4]
        {
            get
            {
                if (Rank > 3)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,,,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name),
                        Expression.Parameter(typeof(int), index2.Name), Expression.Parameter(typeof(int), index3.Name),
                        Expression.Parameter(typeof(int), index4.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2, index3, index4), value);
            }
        }

        public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5]
        {
            get
            {
                if (Rank > 4)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,,,,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name),
                        Expression.Parameter(typeof(int), index2.Name), Expression.Parameter(typeof(int), index3.Name),
                        Expression.Parameter(typeof(int), index4.Name), Expression.Parameter(typeof(int), index5.Name) }));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2, index3, index4, index5), value);
            }
        }

        public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6]
        {
            get
            {
                if (Rank > 5)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,,,,,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name),
                        Expression.Parameter(typeof(int), index2.Name), Expression.Parameter(typeof(int), index3.Name),
                        Expression.Parameter(typeof(int), index4.Name), Expression.Parameter(typeof(int), index5.Name),
                        Expression.Parameter(typeof(int), index6.Name)}));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2, index3, index4, index5), value);
            }
        }

        public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7]
        {
            get
            {
                if (Rank > 6)
                {
                    return new TensorExpression(Expression.MakeIndex(Expression.Constant(new TensorExpression[,,,,,,] { }), null, new Expression[] {
                        Expression.Parameter(typeof(int), index1.Name),
                        Expression.Parameter(typeof(int), index2.Name), Expression.Parameter(typeof(int), index3.Name),
                        Expression.Parameter(typeof(int), index4.Name), Expression.Parameter(typeof(int), index5.Name),
                        Expression.Parameter(typeof(int), index6.Name), Expression.Parameter(typeof(int), index7.Name)}));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
            set
            {
                ThrowIfAlreadyAssiged();
                Assignment = (new IndexSet(index1, index2, index3, index4, index5, index6, index7), value);
            }
        }
        #endregion


        public static Tensor OneD(string name) => new Tensor(name, new int[1]);

        public static Tensor OneD(string name, string indexName, out Index index)
        {
            index = new IndexSet(1, indexName);
            return new Tensor(name, new int[1]);
        }

        public static Tensor TwoD(string name) => new Tensor(name, new int[2]);
        public static Tensor TwoD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, out I, indexNameBase, new int[2]);
        public static Tensor TwoD(string name, string indexNameBase, out Index index1, out Index index2)
        {
            (index1, index2)  = new IndexSet(2, indexNameBase);
            return new Tensor(name, new int[2]);
        }

        public static Tensor ThreeD(string name) => new Tensor(name, new int[3]);
        public static Tensor ThreeD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, out I, indexNameBase, new int[3]);
        public static Tensor ThreeD(string name, string indexNameBase, out Index index1, out Index index2, out Index index3)
        {
            (index1, index2, index3) = new IndexSet(3, indexNameBase);
            return new Tensor(name, new int[3]);
        }


        public static Tensor FourD(string name) => new Tensor(name, new int[4]);
        public static Tensor FourD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, indexNameBase, out I, new int[4]);
        public static Tensor FourD(string name, string indexNameBase, out Index index1, out Index index2, out Index index3, out Index index4)
        {
            (index1, index2, index3, index4) = new IndexSet(4, indexNameBase);
            return new Tensor(name, new int[4]);
        }

        public static Tensor FiveD(string name) => new Tensor(name, new int[5]);
        public static Tensor FiveD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, indexNameBase, out I, new int[5]);
        public static Tensor FiveD(string name, string indexNameBase, out Index index1, out Index index2, out Index index3, out Index index4, out Index index5)
        {
            (index1, index2, index3, index4, index5) = new IndexSet(5, indexNameBase);
            return new Tensor(name, new int[5]);
        }

        public static Tensor SixD(string name) => new Tensor(name, new int[6]);
        public static Tensor SixD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, indexNameBase, out I, new int[6]);
        public static Tensor SixD(string name, string indexNameBase, out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6)
        {
            (index1, index2, index3, index4, index5, index6) = new IndexSet(6, indexNameBase);
            return new Tensor(name, new int[6]);
        }

        public static Tensor SevenD(string name) => new Tensor(name, new int[7]);
        public static Tensor SevenD(string name, string indexNameBase, out IndexSet I) => new Tensor(name, indexNameBase, out I, new int[7]);
        public static Tensor SevenD(string name, string indexNameBase, out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7)
        {
            (index1, index2, index3, index4, index5, index6, index7) = new IndexSet(7, indexNameBase);
            return new Tensor(name, new int[7]);
        }

        internal void ThrowIfAlreadyAssiged()
        {
            if (Assignment.IndexSet != null)
            {
                throw new InvalidOperationException("This tensor variable has an existing assigment. You can only assign to a tensor variable once.");
            }
        }

        internal void ThrowIfIndicesExceedRank(int c)
        {
            if (Rank < c) throw new ArgumentOutOfRangeException("The number of indices exceeds the dimensions of this tensor.");
        }
    }
}
