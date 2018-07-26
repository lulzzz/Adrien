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

namespace Adrien.Trees
{
    public class TensorExpressionVisitor : ExpressionVisitor
    {
        public ExpressionTree Tree { get; set; }

        internal Expression LinqExpression;

        internal TreeBuilderContext Context { get; set; }

        public TensorExpressionVisitor(Expression expr, bool visit = true)
        {
            LinqExpression = expr;
            Tree = new ExpressionTree();
            Context = new TreeBuilderContext(Tree);
            if (visit)
            {
                Visit();
            }
        }

        public TensorExpressionVisitor(Expression expr, Tensor lhs, bool visit = true) : base()
        {
            LinqExpression = expr;
            Tree = new ExpressionTree(lhs);
            Context = new TreeBuilderContext(Tree);
            if (visit)
            {
                Visit();
            }
        }

        public TensorExpressionVisitor(Expression expr, (Tensor tensor, IndexSet indices) lhs, bool visit = true) : 
            base()
        {
            LinqExpression = expr;
            Tree = new ExpressionTree(lhs.tensor, lhs.indices);
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
            base.VisitConstant(node);
            Tensor t = null;
            if (node.Value is Array)
            {
                t = FlattenConstantExpressionValue<Tensor>(node);                    
            }
            else if (node.Value is Tensor)
            {
                t = node.Value as Tensor;
            }
            else throw new InvalidOperationException($"Can't convert ConstantExpression {node.ToReadableString()}" + 
                @"of type {node.Value.GetType().Name} to type Tensor.");

            if (!t.IsElementwiseAssigned)
            {
                Context.AddValueNode(t);
            }
            else
            {
                OperatorNode on = Context.AddOperatorNode(TensorOp.ElementWiseAssign);
                using (Context.Internal(on))
                {
                    Context.AddValueNode(t);
                    base.Visit(t.ElementwiseAssignment.Expression.LinqExpression);
                }
            }
            return node;

        }
                            
        protected override Expression VisitIndex(IndexExpression node)
        {
            OperatorNode on = Context.AddOperatorNode(TensorOp.Index);
            using (Context.Internal(on))
            {
                base.VisitIndex(node);

                Tensor t = Context.Tensors.First();
                if (t.Dimensions.Length < Context.TensorIndicesQueue.Count)
                {
                    throw new Exception($"Tensor {t.Name.Label} has {t.Dimensions.Length} dimensions but the tensor indices queue has length {Context.TensorIndicesQueue.Count}.");
                }

                Index[] indices = new Index[Context.TensorIndicesQueue.Count];
                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = Context.TensorIndicesQueue.Dequeue();
                }
                IndexSet set = new IndexSet(t, indices);
                foreach(Index i in set.Indices)
                {
                    i.Set = set;
                }

                Context.AddValueNode(set);
            }

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            base.VisitParameter(node);
            Tensor t = Context.Tensors.First();
            int i = Context.TensorIndicesQueue.Count;
            Context.TensorIndicesQueue.Enqueue(new Index(null, i, t.Dimensions[i], node.Name));
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert)
            {
                base.Visit(node.Operand);
                return node;
            }
            using (Context.Internal(Context.AddOperatorNode(node.NodeType.ToOp())))
            {
                base.VisitUnary(node);
            }
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            using (Context.Internal(Context.AddOperatorNode(node.NodeType.ToOp())))
            {
                base.VisitBinary(node);
            }
            return node;
        }

        
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            using (Context.Internal(Context.AddOperatorNode(node.MethodCallToTensorOp())))
            {
                base.VisitMethodCall(node);
            }
            return node;
        }
        
    }
}
