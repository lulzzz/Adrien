using System;

namespace Adrien.Notation
{
    public class ContractionOperator : IContractionOp
    {
        Func<TensorContraction, TensorContraction> Operation;

        public ContractionOperator(Func<TensorContraction, TensorContraction> op)
        {
            Operation = op;
        }

        public TensorContraction this[TensorContraction e] => Operation(e);
    }
}