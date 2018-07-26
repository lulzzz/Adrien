using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public static class TensorOperators
    {
        public static UnaryOperator Sum { get; } = new UnaryOperator((expr) => Math.SigmaSum(expr));
        public static UnaryOperator Pow2 { get; } = new UnaryOperator((expr) => Math.Square(expr));
        public static UnaryOperator Root2 { get; } = new UnaryOperator((expr) => Math.Sqrt(expr));
    }

   
}
