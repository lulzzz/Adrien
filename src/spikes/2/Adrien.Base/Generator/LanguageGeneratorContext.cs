using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGeneratorContext<TOp, TWriter> : TreeVisitorContext<TOp, string, string >
    {
        public string CurrentText => this.Peek() as string;

        public LanguageGeneratorContext(IExpressionTree tree) : base(tree) {}
    }
}
