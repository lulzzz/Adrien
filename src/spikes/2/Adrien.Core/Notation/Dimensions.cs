using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adrien.Notation
{
    public class Dimensions : List<Dimension>
    {
        public Tensor Tensor { get; protected set; }

        internal Dimensions(Tensor t) : base(t.Dimensions.Select((d,a) => new Dimension(t, a, d)))
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
    }
}
