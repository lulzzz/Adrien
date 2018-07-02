using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGeneratorContext<TOp, TWriter> : TreeVisitorContext<TOp, TWriter, TWriter> where TWriter : LanguageWriter<TOp>
    {
        public LanguageGeneratorContext(IExpressionTree tree) : base(tree)
        {
            
        }
    }
}
