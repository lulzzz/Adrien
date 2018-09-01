using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Adrien.Ast;
using Adrien.Ast.Extensions;
using Adrien.Geometric;
using E = System.Linq.Expressions.Expression;
using IndexExpression = Adrien.Ast.IndexExpression;

namespace Adrien.Numerics.Reference
{
    public class TileCompiler : ITileCompiler
    {
        public IKernel Compile(Tile tile)
        {
            // Removing all complex indices through a tile transformation
            tile = tile.Project();

            var T = typeof(IReadOnlyList<ITensor>);

            var tensors = E.Parameter(T, "tensors");

            var symbols = tile.Symbols();

            var spans = new Dictionary<string, ParameterExpression>();

            // Foo = tensors[0]; Bar = tensors[1]; ...
            var exprList = new List<E>();
            for (var i = 0; i < symbols.Count; i++)
            {
                var s = symbols[i];

                var span = E.Parameter(typeof(Span<>).MakeGenericType(s.ElementType()), s.Name);

                spans.Add(s.Name, span);

                var tensorType = s.Shape.Kind.GetTensorType();

                var assign = E.Assign(span,
                    E.Call(
                        E.Call(
                            E.Convert(
                                E.Call(tensors, T.GetMethod("get_Item"), E.Constant(i)),
                                tensorType),
                            tensorType.GetMethod("get_Buffer")),
                        typeof(Memory<>).MakeGenericType(s.ElementType()).GetMethod("get_Span"))
                );

                exprList.Add(assign);
            }

            foreach (var statement in tile.Statements)
            {
                switch (statement.Kind)
                {
                    case StatementKind.ElementWise:
                        exprList.Add(Compile(statement, spans, "SetSpanItem"));
                        break;
                    case StatementKind.ZeroAndSum:
                        exprList.Add(CompileZero(statement.Left, spans[statement.Left.Symbol.Name]));
                        exprList.Add(Compile(statement, spans, "SetAddSpanItem"));
                        break;
                    case StatementKind.Sum:
                        exprList.Add(Compile(statement, spans, "SetAddSpanItem"));
                        break;
                    case StatementKind.Max:
                        exprList.Add(Compile(statement, spans, "SetMaxSpanItem"));
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            var block = E.Block(spans.Values, exprList);

            return new Kernel(
                E.Lambda<Action<IReadOnlyList<ITensor>>>(block, tensors).Compile());
        }

        static E CompileZero(Element element, ParameterExpression span)
        {
            var nakedIndices = element.Indices();
            var indices = GetIndices(nakedIndices);

            var setterIndex = CompileAsIndex(element, indices);

            var setMethod = typeof(TileCompiler).FindMethod("SetDefaultSpanItem", element.ElementType());

            E inner = E.Call(
                null,
                setMethod,
                span,
                setterIndex
            );

            return CompileLoops(inner, nakedIndices, indices);
        }

        static E Compile(
            Statement statement, 
            Dictionary<string, ParameterExpression> spans,
            string method)
        {
            var nakedIndices = statement.Indices();
            var indices = GetIndices(nakedIndices);

            var setterIndex = CompileAsIndex(statement.Left, indices);

            var setMethod = typeof(TileCompiler).FindMethod(method, statement.Left.ElementType());

            E inner = E.Call(
                null,
                setMethod,
                spans[statement.Left.Symbol.Name],
                setterIndex,
                Compile(statement.Right, spans, indices)
            );

            return CompileLoops(inner, nakedIndices, indices);
        }

        static E CompileLoops(E inner,
            IReadOnlyList<Index> nakedIndices,
            Dictionary<string, ParameterExpression> indices)
        {
            foreach (var index in nakedIndices.Reverse())
            {
                var indexParam = indices[index.Name];

                // The tile has been projected to simple indices.
                inner = indexParam.For(
                    index.Range.Offset,
                    index.Range.Offset + index.Range.Count,
                    inner);
            }

            return E.Block(indices.Values, inner);
        }

        static E Compile(
            ElementExpression expression,
            Dictionary<string, ParameterExpression> spans,
            Dictionary<string, ParameterExpression> indices)
        {
            switch (expression.ArityKind)
            {
                case ArityKind.Element:
                    return Compile(expression.Element, spans, indices);

                case ArityKind.Unary:
                    switch (expression.UnaryKind)
                    {
                        case UnaryExpressionKind.Exp:
                            throw new NotImplementedException();
                        case UnaryExpressionKind.Log:
                            throw new NotImplementedException();
                        default:
                            throw new NotSupportedException();
                            ;
                    }

                case ArityKind.Binary:
                    switch (expression.BinaryKind)
                    {
                        case BinaryExpressionKind.Add:
                            return E.Add(
                                Compile(expression.Expr1, spans, indices),
                                Compile(expression.Expr2, spans, indices));

                        case BinaryExpressionKind.Subtract:
                            return E.Add(
                                Compile(expression.Expr1, spans, indices),
                                E.Negate(Compile(expression.Expr2, spans, indices)));

                        case BinaryExpressionKind.Multiply:
                            return E.Multiply(
                                Compile(expression.Expr1, spans, indices),
                                Compile(expression.Expr2, spans, indices));

                        case BinaryExpressionKind.Divide:
                            return E.Divide(
                                Compile(expression.Expr1, spans, indices),
                                Compile(expression.Expr2, spans, indices));

                        case BinaryExpressionKind.Embed:
                            throw new NotImplementedException();

                        default:
                            throw new NotSupportedException();
                    }

                case ArityKind.Ternary:
                    throw new NotImplementedException();

                default:
                    throw new NotSupportedException();
            }
        }

        static E Compile(
            Element element,
            Dictionary<string, ParameterExpression> spans,
            Dictionary<string, ParameterExpression> indices)
        {
            var index = CompileAsIndex(element, indices);

            return E.Call(
                null,
                typeof(TileCompiler).FindMethod("GetSpanItem", element.ElementType()),
                spans[element.Symbol.Name],
                index
            );
        }

        static E CompileAsIndex(
            Element element, Dictionary<string, ParameterExpression> indices)
        {
            var strides = element.Symbol.Shape.Strides();

            var expr = Compile(element.Expressions.Last(), indices);

            for (var i = element.Expressions.Count - 2; i >= 0; i--)
            {
                expr = E.Add(
                    E.Multiply(
                        E.Constant(strides[i]),
                        Compile(element.Expressions[i], indices)),
                    expr);
            }

            return expr;
        }

        static E Compile(
            IndexExpression expression, Dictionary<string, ParameterExpression> indices)
        {
            switch (expression.ArityKind)
            {
                case IndexExpressionArityKind.Constant:
                    return E.Constant(expression.Constant);

                case IndexExpressionArityKind.Index:
                    return indices[expression.Index.Name];

                case IndexExpressionArityKind.Binary:
                    switch (expression.BinaryKind)
                    {
                        case BinaryExpressionKind.Add:
                            return E.Add(
                                Compile(expression.Expr1, indices),
                                Compile(expression.Expr2, indices));

                        case BinaryExpressionKind.Subtract:
                            return E.Add(
                                Compile(expression.Expr1, indices),
                                E.Negate(Compile(expression.Expr2, indices)));

                        case BinaryExpressionKind.Multiply:
                            return E.Multiply(
                                Compile(expression.Expr1, indices),
                                Compile(expression.Expr2, indices));

                        case BinaryExpressionKind.Divide:
                            return E.Divide(
                                Compile(expression.Expr1, indices),
                                Compile(expression.Expr2, indices));

                        case BinaryExpressionKind.Embed:
                            throw new NotSupportedException();

                        default:
                            throw new NotSupportedException();
                    }

                default:
                    throw new NotSupportedException();
            }
        }


        static Dictionary<string, ParameterExpression> GetIndices(IReadOnlyList<Index> nakedIndices)
        {
            var indices = new Dictionary<string, ParameterExpression>();
            for (var i = 0; i < nakedIndices.Count; i++)
            {
                var idx = nakedIndices[i];
                var index = E.Parameter(typeof(int), idx.Name);
                indices.Add(idx.Name, index);
            }

            return indices;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetSpanItem<T>(Span<T> span, int index)
        {
            // TODO: work-around on https://stackoverflow.com/questions/52105111/arithmetic-on-floats-with-linq-expression-trees
            return span[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetDefaultSpanItem<T>(Span<T> span, int index)
        {
            span[index] = default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetAddSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] += value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetAddSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] += value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetMaxSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] = span[index] > value ? span[index] : value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetMaxSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] = span[index] > value ? span[index] : value;
        }
    }
}