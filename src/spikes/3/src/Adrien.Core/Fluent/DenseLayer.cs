using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public static partial class Layer
    {
        public static FluentSymbol Dense(this FluentFlowGraph graph, FluentSymbol input)
        {
            var (l, w, b, res) = graph.GetFlow3Var("W", "b", "res");

            l.Add2((i,j) => res[i] = w[i, j] * input[j] + b[i]);

            return res;
        }
    }
}
