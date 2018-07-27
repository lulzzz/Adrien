using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    public class ContractionOperator : IContractionOp
    {
        Func<TensorContraction, TensorContraction> Operation;

        public ContractionOperator(Func<TensorContraction, TensorContraction> op)
        {
            this.Operation = op;
        }

        public TensorContraction this[TensorContraction e] => Operation(e); 
    } 
}
