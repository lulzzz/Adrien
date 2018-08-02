using System;

namespace Adrien.Notation
{
    public class ContractionOperator : IContractionOp
    {
        Func<TensorIndexExpression, TensorContraction> Operation;

        public ContractionOperator(Func<TensorIndexExpression, TensorContraction> op)
        {
            Operation = op;
        }

        public TensorContraction this[TensorIndexExpression e] => Operation(e);
    }
}