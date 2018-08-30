namespace Adrien.Core
{
    public enum StatementKind
    {
        ElementWise,
        ZeroAndSum,
        Sum,
        Max
    }

    /// <summary>
    /// One logical calculation step within a tile.
    /// </summary>
    public class Statement
    {
        public StatementKind Kind { get; }

        public Element Left { get; }

        public ElementExpression Right { get; }

        public Statement(StatementKind kind, Element left, ElementExpression right)
        {
            Kind = kind;
            Left = left;
            Right = right;
        }
    }
}