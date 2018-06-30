using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using AgileObjects.ReadableExpressions;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public ExpressionTree Tree { get; set; }

        internal Expression LinqExpression;

        internal TreeBuilderContext Context { get; set; }


        public TensorExpressionVisitor(Expression expr, bool visit = true) : base()
        {
            LinqExpression = expr;
            Tree = new ExpressionTree();
            Context = new TreeBuilderContext(Tree);
            if (visit)
            {
                Visit();
            }
        }


        public void Visit()
        {
            this.Visit(this.LinqExpression);
        }

        internal static TReturn FlattenConstantExpressionValue<TReturn>(ConstantExpression node)
        {
            Array a = (Array)node.Value;
            return a.Flatten<TReturn>().First();
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Tensor t = null;
            if (node.Value is Array)
            {
                t = FlattenConstantExpressionValue<Tensor>(node);
                    
            }
            else throw new InvalidOperationException($"Can't convert ConstantExpression {node.ToReadableString()} of type {node.Value.GetType().Name} to type Tensor.");

            Context.AddValueNode(t);
            return node;
           
        }
                            
        protected override Expression VisitIndex(IndexExpression node)
        {
            using (var op = Context.Internal(node.NodeType.ToOp()))
            {
                OperatorNode on = Context.AddOperatorNode(Context.InternalNode);
                using (var opnd = Context.Leaf(node.Object))
                {
                    this.Visit(node.Object);
                }

                Tensor t = Context.LastTreeValueNodeAs<Tensor>();
         
                Index[] indices = new Index[node.Arguments.Count];

                for (int i = 0; i < node.Arguments.Count; i++)
                {
                    using (var opnd = Context.Leaf(node.Arguments[i]))
                    {
                        base.Visit(node.Arguments[i]);
                        Index ix = new Index(null, i, t.Dimensions[i], (node.Arguments[1].As<ParameterExpression>().Name));
                        indices[i] = ix;
                    }
                }

                Context.AddValueNode(on, new IndexSet(indices));
            }
            return node;
        }
    }
}
