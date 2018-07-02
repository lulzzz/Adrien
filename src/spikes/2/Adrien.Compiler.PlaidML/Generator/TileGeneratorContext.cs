using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Generator;
using Adrien.Trees;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileGeneratorContext : LanguageGeneratorContext<TileWriter>
    {
        public TileGeneratorContext(IExpressionTree tree) : base(tree)
        {

        }
    }
}
