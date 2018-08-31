﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Adrien.Core.Extensions;
using static System.Linq.Expressions.Expression;
using E = System.Linq.Expressions.Expression;

namespace Adrien.Core.Numerics.Cpu
{
    public class CpuTileCompiler : ITileCompiler
    {
        public IKernel Compile(Tile tile)
        {
            var T = typeof(IReadOnlyList<ITensor>);

            var tensors = Parameter(T, "tensors");

            var symbols = new List<Symbol>();
            symbols.AddRange(tile.Inputs);
            symbols.AddRange(tile.Outputs);

            var spans = new Dictionary<string, ParameterExpression>();

            // Foo = tensors[0]; Bar = tensors[1]; ...
            var exprList = new List<E>();
            for (var i = 0; i < symbols.Count; i++)
            {
                var s = symbols[i];

                var span = Parameter(typeof(Span<>).MakeGenericType(s.ElementType()), s.Name);

                spans.Add(s.Name, span);

                var tensorType = s.Shape.Kind.GetTensorType();

                var assign = Assign(span,
                    Call(
                        Call(
                            Convert(
                                Call(tensors, T.GetMethod("get_Item"), Constant(i)),
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
                    case StatementKind.ZeroAndSum:
                        exprList.Add(CompileZero(statement.Left, spans[statement.Left.Symbol.Name]));
                        exprList.Add(CompileSum(statement, spans));
                        break;
                    case StatementKind.Sum:
                        exprList.Add(CompileSum(statement, spans));
                        break;
                    case StatementKind.ElementWise:
                        throw new NotImplementedException();
                    case StatementKind.Max:
                        throw new NotImplementedException();
                    default:
                        throw new NotSupportedException();
                }
            }

            var block = Block(spans.Values, exprList);

            return new CpuKernel(
                Lambda<Action<IReadOnlyList<ITensor>>>(block, tensors).Compile());
        }

        static E CompileZero(Element element, ParameterExpression span)
        {
            var nakedIndices = element.Indices();
            var indices = GetIndices(nakedIndices);

            var setterIndex = CompileAsIndex(element, indices);

            var setMethod = typeof(CpuTileCompiler).FindMethod("SetDefaultSpanItem", element.ElementType());

            E inner = Call(
                null,
                setMethod,
                span,
                setterIndex
            );

            return CompileLoops(inner, nakedIndices, indices);
        }

        static E CompileSum(Statement statement, Dictionary<string, ParameterExpression> spans)
        {
            var nakedIndices = statement.Indices();
            var indices = GetIndices(nakedIndices);

            var setterIndex = CompileAsIndex(statement.Left, indices);

            var setMethod = typeof(CpuTileCompiler).FindMethod("SetAddSpanItem", statement.Left.ElementType());

            E inner = Call(
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

                // TODO: [vermorel] not handling multi-range indices yet
                inner = indexParam.For(
                    index.Ranges[0].Offset,
                    index.Ranges[0].Offset + index.Ranges[0].Count,
                    inner);
            }

            return Block(indices.Values, inner);
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
                            return Add(
                                Compile(expression.Expr1, spans, indices),
                                Compile(expression.Expr2, spans, indices));

                        case BinaryExpressionKind.Subtract:
                            return Add(
                                Compile(expression.Expr1, spans, indices),
                                Negate(Compile(expression.Expr2, spans, indices)));

                        case BinaryExpressionKind.Multiply:
                            return Multiply(
                                Compile(expression.Expr1, spans, indices),
                                Compile(expression.Expr2, spans, indices));

                        case BinaryExpressionKind.Divide:
                            return Divide(
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

            return Call(
                null,
                typeof(CpuTileCompiler).FindMethod("GetSpanItem", element.ElementType()),
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
                expr = Add(
                    Multiply(
                        Constant(strides[i]),
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
                    return Constant(expression.Constant);

                case IndexExpressionArityKind.Index:
                    return indices[expression.Index.Name];

                case IndexExpressionArityKind.Binary:
                    switch (expression.BinaryKind)
                    {
                        case BinaryExpressionKind.Add:
                            return Add(
                                Compile(expression.Expr1, indices),
                                Compile(expression.Expr2, indices));

                        case BinaryExpressionKind.Subtract:
                            return Add(
                                Compile(expression.Expr1, indices),
                                Negate(Compile(expression.Expr2, indices)));

                        case BinaryExpressionKind.Multiply:
                            return Multiply(
                                Compile(expression.Expr1, indices),
                                Compile(expression.Expr2, indices));

                        case BinaryExpressionKind.Divide:
                            return Divide(
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
                var index = Parameter(typeof(int), idx.Name);
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
        private static void SetAddSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] += value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetAddSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] += value;
        }
    }
}