using System;
using Adrien.Core.Symbolic;

namespace Adrien.Core.Fluent
{
    public class FluentFlow : Flow
    {
        public void Add1(Func<FluentIndex, FluentStatement> eval)
        {
            var index = new FluentIndex();
            var statement = eval(index);
            statement.Add(index);

            Add(statement);
        }

        public void Add2(Func<FluentIndex, FluentIndex, FluentStatement> eval)
        {
            var index1 = new FluentIndex();
            var index2 = new FluentIndex();
            var statement = eval(index1, index2);
            statement.Add(index1);
            statement.Add(index2);

            Add(statement);
        }
    }
}
