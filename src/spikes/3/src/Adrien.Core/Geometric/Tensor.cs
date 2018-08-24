using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Core
{
    class Tensor
    {
        public ElementKind Kind { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public int[] Dimensions { get; set; }
    }
}
