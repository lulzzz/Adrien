using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
namespace Adrien.Notation
{
    public class Tensor<T> : Term where T : unmanaged
    {
        #region Constructors
        public Tensor(string name, params int [] dim) : base(name)
        {
            Dimensions = dim;
        }

     
        public Tensor(string name, out IndexSet I, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(dim.Length);
        }

        public Tensor(string name, string indexNameBase, out IndexSet I, params int[] dim) : this(name, dim)
        {
            I = new IndexSet(dim.Length, indexNameBase);
        }

        #endregion

        #region Overriden members
        internal override Expression LinqExpression => Expression.Constant(this);
        internal override Name DefaultNameBase { get; } = "T";
        #endregion

        #region Properties
        public int[] Dimensions { get; protected set; }

        public int Rank => Dimensions.Length;
        #endregion

        #region Operators

        #region Indexers
        public static implicit operator TensorExpression<T>(Tensor<T> t)
        {
            return new TensorExpression<T>(t.LinqExpression);
        }

        public TensorExpression<T> this[IndexSet index]
        {
            get
            {
                if (Rank <= index.DimensionCount)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index.Indices.Cast<Expression>()));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index]
        {
            get
            {
                if (Rank > 0)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2]
        {
            get
            {
                if (Rank > 1)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2, Index index3]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2, index3));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2, Index index3, Index index4]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2, index3, index4));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2, Index index3, Index index4, Index index5]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2, index3, index4, index5));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2, index3, index4, index5, index6));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }

        public TensorExpression<T> this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7]
        {
            get
            {
                if (Rank > 2)
                {
                    return new TensorExpression<T>(Expression.ArrayIndex(this, index1, index2, index3, index4, index5, index6, index7));
                }
                else throw new ArgumentOutOfRangeException($"This tensor has rank {Rank}.");
            }
        }
        #endregion

        #endregion

        #region Methods
        public static Tensor<T> OneD(string name) => new Tensor<T>(name, 1);
        public static Tensor<T> OneD(string name, string indexNameBase, out IndexSet I) => new Tensor<T>(name, out I, 1);

        public static Tensor<T> TwoD(string name) => new Tensor<T>(name, 2);
        public static Tensor<T> TwoD(string name, out IndexSet I) => new Tensor<T>(name, out I, 2);

        public static Tensor<T> ThreeD(string name) => new Tensor<T>(name, 3);
        public static Tensor<T> ThreeD(string name, out IndexSet I) => new Tensor<T>(name, out I, 3);

        public static Tensor<T> FourD(string name) => new Tensor<T>(name, 4);
        public static Tensor<T> FourD(string name, out IndexSet I) => new Tensor<T>(name, out I, 4);

        public static Tensor<T> FiveD(string name) => new Tensor<T>(name, 5);
        public static Tensor<T> FiveD(string name, out IndexSet I) => new Tensor<T>(name, out I, 5);

        public static Tensor<T> SixD(string name) => new Tensor<T>(name, 6);
        public static Tensor<T> SixD(string name, out IndexSet I) => new Tensor<T>(name, out I, 6);

        public static Tensor<T> SevenD(string name) => new Tensor<T>(name, 7);
        public static Tensor<T> SevenD(string name, out IndexSet I) => new Tensor<T>(name, out I, 7);
        #endregion
    }
}
