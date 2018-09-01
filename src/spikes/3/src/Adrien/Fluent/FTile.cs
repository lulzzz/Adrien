using System;

namespace Adrien.Fluent
{
    public class FTile
    {
        public void Sum(Func<FIndex, FStatement> eval)
        {
            throw new NotImplementedException();
        }

        public void Sum(Func<FIndex, FIndex, FStatement> eval)
        {
            throw new NotImplementedException();
        }

        public void Add(FStatement statement)
        {
            throw new NotImplementedException();
        }

        public void Add(FVariable symbol)
        {
            throw new NotImplementedException();
        }
    }
}
