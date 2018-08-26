using System;

namespace Adrien.Core.Fluent
{
    /// <summary>
    /// A symbol when operating at the tile level.
    /// </summary>
    public class FSymbol
    {
        public FSymbol(string name)
        {
            throw new NotImplementedException();
        }

        public FElementExpression this[FIndexExpression expr1]
        {
            get
            {
                return new FElementExpression(new FElement(this, expr1));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public FElementExpression this[FIndexExpression expr1, FIndexExpression expr2]
        {
            get
            {
                return new FElementExpression(new FElement(this, expr1));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public static (FSymbol, FSymbol) New(string name1, string name2)
        {
            return (new FSymbol(name1), new FSymbol(name2));
        }

        public static (FSymbol, FSymbol, FSymbol, FSymbol) New(
            string name1, string name2, string name3, string name4)
        {
            return (new FSymbol(name1), new FSymbol(name2), new FSymbol(name3), new FSymbol(name4));
        }
    }
}
