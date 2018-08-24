using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Core
{
    public class NDArray
    {
        public ElementKind Kind { get; set; }

        public int Rank { get; }

        public int[] Dimensions { get; }

        public int[] Strides { get; }
    }
}
