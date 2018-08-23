using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public static partial class Math
    {
        public static TensorIndexExpression Sum(TensorIndexExpression l) => 
            new TensorIndexExpression(GetOpMethodCall("Sum", l));

        public static TensorIndexExpression Product(TensorIndexExpression l) =>
           new TensorIndexExpression(GetOpMethodCall("Product", l));

        public static TensorIndexExpression Max(TensorIndexExpression l) =>
            new TensorIndexExpression(GetOpMethodCall("Max", l));

        public static TensorIndexExpression Min(TensorIndexExpression l) =>
            new TensorIndexExpression(GetOpMethodCall("Min", l));

        public static TensorIndexExpression Mean(TensorIndexExpression l)
        {
            var tensor = (Tensor) l;
            var indices = l.IndexParameters;
            var mulExpr = tensor.GetDimensionProductExpression(indices);
            return Sum(l) / mulExpr;
        }
    }


    public partial class TensorExpression
    {
        private static TensorIndexExpression Op_Sum(TensorIndexExpression l) => null;
        private static TensorIndexExpression Op_Product(TensorIndexExpression l) => null;
    }
}
