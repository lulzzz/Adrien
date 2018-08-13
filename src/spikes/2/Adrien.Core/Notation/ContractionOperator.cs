using System;

namespace Adrien.Notation
{
    public class ContractionOperator : IContractionOp
    {
        Func<TensorIndexExpression, TensorIndexExpression> Operation;

        public ContractionOperator(Func<TensorIndexExpression, TensorIndexExpression> op)
        {
            Operation = op;
        }

        public TensorIndexExpression this[TensorIndexExpression e] => Operation(e);
    }
}