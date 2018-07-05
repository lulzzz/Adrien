using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Generator;
using Adrien.Trees;

namespace Adrien.Compiler.PlaidML.Generator
{
    public class TileGenerator : LanguageGenerator<TensorOp, TileWriter>
    {
        public TileGenerator(IExpressionTree tree) : base(tree)
        {
            Context = new TileGeneratorContext(tree);
            Writer = new TileWriter();
            this.VisitTree();
        }

        public override void AfterVisitTree()
        {
            base.AfterVisitTree();

            ITreeOperatorNode<TensorOp> root = (ITreeOperatorNode<TensorOp>)Tree.Root;
            if (root.Left is ITreeValueNode)
            {
                ITreeValueNode l = (ITreeValueNode)root.Left;
                if (l.Value == null)
                {
                    string text = Text.Remove(0, "[] = ".Length);
                    this.Context.Push(text);
                }
            }
        }
    }
}

