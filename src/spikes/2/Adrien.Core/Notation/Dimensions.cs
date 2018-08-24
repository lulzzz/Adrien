using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adrien.Notation
{
    public class Shape : List<Dimension>
    {
        public Tensor Tensor { get; protected set; }

        internal Shape() : base(0)
        {
            
        }

        internal Shape(params Dimension[] dim) : base(dim)
        {

        }

        internal Shape(Tensor t) : base(t.Dimensions.Select((d,a) => new Dimension(t, a, d)))
        {
            this.Tensor = t;
        }

        public Dimension this[Index i]
        {
            get
            {
                if(i.Type != IndexType.Dimension)
                {
                    throw new ArgumentException("This index is a dimension expression or literal, not a dimension.");
                }
                else
                {
                    Tensor.ThrowIfIndicesExceedRank(i.Order);
                    return base[i.Order];
                }
            }
        }

        public new Dimension this[int i] => base[i];

        public static explicit operator IndexSet(Shape d) => new IndexSet(d.Tensor);
    }
}
