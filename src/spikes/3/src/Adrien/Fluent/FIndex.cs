namespace Adrien.Fluent
{
    public class FIndex 
    {
        public static implicit operator FIndexExpression(FIndex index)
        {
            var term = new FIndexExpression(index);

            return term;
        }
    }
}
