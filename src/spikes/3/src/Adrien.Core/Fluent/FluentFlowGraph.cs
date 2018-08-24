using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentFlowGraph : FlowGraph
    {
        public (FluentFlow, FluentSymbol) GetFlow1Var(string name1)
        {
            var flow = new FluentFlow();
            var symbol = new FluentSymbol(name1);

            flow.Add(symbol);

            Add(flow);

            return (flow, symbol);
        }

        public (FluentFlow, FluentSymbol, FluentSymbol) GetFlow2Var(string name1, string name2)
        {
            var flow = new FluentFlow();
            var symbol1 = new FluentSymbol(name1);
            var symbol2 = new FluentSymbol(name2);

            flow.Add(symbol1);
            flow.Add(symbol2);

            Add(flow);

            return (flow, symbol1, symbol2);
        }

        public (FluentFlow, FluentSymbol, FluentSymbol, FluentSymbol) GetFlow3Var(string name1, string name2, string name3)
        {
            var flow = new FluentFlow();
            var symbol1 = new FluentSymbol(name1);
            var symbol2 = new FluentSymbol(name2);
            var symbol3 = new FluentSymbol(name3);

            flow.Add(symbol1);
            flow.Add(symbol2);
            flow.Add(symbol3);

            Add(flow);

            return (flow, symbol1, symbol2, symbol3);
        }

    }
}
