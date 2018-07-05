using System;
using System.Collections.Generic;
using System.Text;

using N = Adrien.Notation;
using Adrien.Generator;
using Adrien.Trees;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileWriter : LanguageWriter<TensorOp> 
    {
        protected override Dictionary<TensorOp, string> OperatorTemplate { get; } = new Dictionary<TensorOp, string>
        {
            { TensorOp.Assign, "{0} = {1}" },
            { TensorOp.Summation, "{0}[{1}]" },
            { TensorOp.Mul, "{0} * {1}" }
        };

    }
}
