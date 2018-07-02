using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Generator;
using Adrien.Trees;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileGenerator : LanguageGenerator<Op>
    {
        public TileGenerator(IExpressionTree tree) : base(tree)
        {

        }

        public override void VisitInternal(ITreeOperatorNode<Op> on)
        {
            base.VisitInternal(on);
        }

        public override void VisitLeaf(ITreeValueNode node)
        {
            throw new NotImplementedException();
        }

        public override void AfterVisit()
        {
            throw new NotImplementedException();
        }
    }
}
