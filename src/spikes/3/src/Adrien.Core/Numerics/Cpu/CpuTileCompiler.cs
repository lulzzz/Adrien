using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Adrien.Core.Extensions;


namespace Adrien.Core.Numerics.Cpu
{
    public class CpuTileCompiler : ITileCompiler
    {
        public IKernel Compile(Tile tile)
        {
            var T = typeof(IReadOnlyList<ITensor>);

            var tensors = Expression.Parameter(T, "tensors");

            var symbols = new List<Symbol>();
            symbols.AddRange(tile.Inputs);
            symbols.AddRange(tile.Outputs);

            var spanMap = new Dictionary<string, ParameterExpression>();

            // Foo = tensors[0]; Bar = tensors[1]; ...
            var init = new List<Expression>();
            for (var i = 0; i < symbols.Count; i++)
            {
                var s = symbols[i];

                var elementType = s.Shape.Kind.GetMatchingType();

                var span = Expression.Parameter(typeof(Span<>).MakeGenericType(elementType), s.Name);

                spanMap.Add(s.Name, span);

                var tensorType = s.Shape.Kind.GetTensorType();

                var assign = Expression.Assign(span,
                    Expression.Call(
                        Expression.Call(
                            Expression.Convert(
                                Expression.Call(tensors, T.GetMethod("get_Item"), Expression.Constant(i)),
                                tensorType),
                            tensorType.GetMethod("get_Buffer")),
                        typeof(Memory<>).MakeGenericType(s.Shape.Kind.GetMatchingType()).GetMethod("get_Span"))
                    );

                init.Add(assign);
            }

            // TODO: [vermorel] process each statement

            var block = Expression.Block(
                spanMap.Values,
                init);

            return new CpuKernel(Expression.Lambda<Action<IReadOnlyList<ITensor>>>(block, tensors).Compile());
        }

        static Expression Compile(Statement statement, Dictionary<string, ParameterExpression> tensors)
        {
            // TODO: [vermorel] not handling multi-range indices yet

            var indices = statement.Indices();

            var indexMap = new Dictionary<string, ParameterExpression>();
            for (var i = 0; i < indices.Count; i++)
            {
                var idx = indices[i];

                var index = Expression.Parameter(typeof(int), idx.Name);

                indexMap.Add(idx.Name, index);
            }

            return null;
        }

        static Expression CompileIndex(Element element, Dictionary<string, ParameterExpression> indices)
        {
            var strides = element.Symbol.Shape.Strides();

            var expr = Compile(element.Expressions.Last(), indices);

            for (var i = element.Expressions.Count - 2; i >= 0; i++)
            {
                expr = Expression.Add(
                    Expression.Multiply(
                        Expression.Constant(strides[i]),
                        Compile(element.Expressions[i], indices)), 
                    expr);
            }

            return expr;
        }

        static Expression Compile(IndexExpression expression, Dictionary<string, ParameterExpression> indices)
        {
            return null;
        }
    }
}
