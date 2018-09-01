using System.Linq.Expressions;
using E = System.Linq.Expressions.Expression;

namespace Adrien.Numerics.Reference
{
    public static class ExpressionExtensions
    {
        /// <summary>for(loopVar = min; i &lt; max; i++) { loopContent }</summary>
        public static E For(this ParameterExpression loopVar, int min, int max, E loopContent)
        {
            var initAssign = E.Assign(loopVar, E.Constant(min, typeof(int)));

            var breakLabel = E.Label("LoopBreak");

            var loop = E.Block(new[] { loopVar },
                initAssign,
                E.Loop(
                    E.IfThenElse(
                        E.LessThan(loopVar, E.Constant(max, typeof(int))),
                        E.Block(
                            loopContent,
                            E.Assign(loopVar, E.Increment(loopVar))
                        ),
                        E.Break(breakLabel)
                    ),
                    breakLabel)
            );

            return loop;
        }
    }
}
