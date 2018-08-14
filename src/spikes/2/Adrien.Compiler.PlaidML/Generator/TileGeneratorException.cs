using System;
using System.Collections.Generic;
using System.Text;
using Adrien.Trees;
using Adrien.Generator;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileGeneratorException : LanguageGeneratorException<TensorOp, TileWriter>
    {
        public TileGeneratorException(TileGenerator gen, string message) : base(gen, message) {}
    }
}
