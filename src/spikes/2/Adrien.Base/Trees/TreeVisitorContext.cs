using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Adrien.Trees
{
    public abstract class TreeVisitorContext<TOp, TInternal, TLeaf> : Stack<object>, ITreeVisitorContext<TOp, TInternal, TLeaf>
    {
        public IExpressionTree Tree { get; protected set; }

        public bool IsInternal => this.Count > 0 && this.Peek() is TInternal;

        public bool IsLeaf => this.Count > 0 && this.Peek() is TLeaf;

        public TInternal InternalNode => this.Peek() is TInternal ? (TInternal) this.Peek() : throw new Exception("The last context node is not a internal node.");

        public TLeaf LeafNode => this.Peek() is TInternal ? (TLeaf) this.Peek() : throw new Exception("The last context node is not a leaf node.");

        public TreeVisitorContext(IExpressionTree tree) : base()
        {
            this.Tree = tree;
        }


        public new void Push(object node)
        {
            if (node is TLeaf || node is TInternal)
            {
                base.Push(node);
            }
            else throw new Exception("The object to push is not a leaf or internal context node.");
        }

        //public new void Pop() => throw new NotSupportedException("Use the PopInternal() or PopLeaf() methods to pop context nodes.");

        public TInternal PopInternal()
        {
            if (this.IsInternal)
            {
                return (TInternal) base.Pop();
            }
            else return InternalNode;
        }

        public TLeaf PopLeaf()
        {
            if (this.IsLeaf)
            {
                return (TLeaf) base.Pop();
            }
            else return LeafNode;
        }

     
        public ITreeVisitorContext<TOp, TInternal, TLeaf> Internal(TInternal ctx)
        {
            this.Push(ctx);
            return this;
        }
        
        public ITreeVisitorContext<TOp, TInternal, TLeaf> Leaf (TLeaf ctx)
        {
            this.Push(ctx);
            return this;
        }

        
        public void Dispose()
        {
            this.Pop();
        }

    }
}
