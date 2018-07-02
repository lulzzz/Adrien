using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageGenerator<TOp> : TreeVisitor<TOp, ITreeOperatorNode<TOp>, ITreeOperatorNode<TOp>>
    {
        public LanguageGenerator(IExpressionTree tree) : base(tree, false)
        {

        }
    }
}
