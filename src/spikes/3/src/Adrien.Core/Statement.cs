namespace Adrien.Core
{
    public enum StatementKind
    {
        ElementWise,
        Sum,
        Max
    }

    /// <summary>
    /// One logical calculation step within a tile.
    /// </summary>
    public class Statement
    {
        public bool InitializeAtZero { get; }

        public StatementKind Kind { get; }

        public ElementExpression Left { get; }

        public ElementExpression Right { get; }

        public Statement(bool initializeAtZero, StatementKind kind, 
            ElementExpression left, ElementExpression right)
        {
            InitializeAtZero = initializeAtZero;
            Kind = kind;
            Left = left;
            Right = right;
        }
    }
}
