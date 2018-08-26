namespace Adrien.Core
{
    public enum IndexExpressionArityKind
    {
        Constant,
        Term,
        Binary
    }

    public enum BinaryIndexExpressionKind
    {
        None,

        Add,
        Subtract,
        Multiply,
        Divide
    }

    /// <summary>
    /// An expression that logically represents the calculation
    /// associated to index that parametrizes the access to a symbol. 
    /// </summary>
    public class IndexExpression
    {
        public IndexExpressionArityKind ArityKind { get; }

        public BinaryExpressionKind BinaryKind { get; }

        public int Constant { get; }

        public Index Term { get; }

        public IndexExpression Expr1 { get; }

        public IndexExpression Expr2 { get; }

        public IndexExpression(int constant)
        {
            ArityKind = IndexExpressionArityKind.Constant;
            BinaryKind = BinaryExpressionKind.None;
            Constant = constant;
        }

        public IndexExpression(Index term)
        {
            ArityKind = IndexExpressionArityKind.Term;
            BinaryKind = BinaryExpressionKind.None;
            Term = term;
        }

        public IndexExpression(BinaryExpressionKind kind,
            IndexExpression expr1, IndexExpression expr2)
        {
            ArityKind = IndexExpressionArityKind.Binary;
            BinaryKind = kind;
            Expr1 = expr1;
            Expr2 = expr2;
        }
    }
}
