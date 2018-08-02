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
                if (i.Set == null || i.Set.Tensor == null || i.Set.Tensor != this.Tensor)
                {
                    throw new Exception($"This index does not belong to an index set of tensor {Tensor.Name}.");
                }
                else
                {
                    Tensor.ThrowIfIndicesExceedRank(i.Dimension);
                    return this[i.Dimension];
                }
            }
        }
    }
}
