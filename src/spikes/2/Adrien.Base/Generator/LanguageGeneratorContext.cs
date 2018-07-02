using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGeneratorContext<TWriter> : TreeVisitorContext<Op, TWriter, TWriter> where TWriter : LanguageWriter<Op>
    {
        public LanguageGeneratorContext(IExpressionTree tree) : base(tree)
        {
            
        }
    }
}
