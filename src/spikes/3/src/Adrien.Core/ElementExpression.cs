namespace Adrien.Core
{
    public enum ArityKind
    {
        Element,
        Unary,
        Binary,
        Ternary
    }

    public enum UnaryExpressionKind
    {
        None,

        Exp,
        Log
    }

    public enum BinaryExpressionKind
    {
        None,

        Add,
        Subtract,
        Multiply,
        Divide,

        /// <summary>
        /// Special operation dedicated to lookup table embedding.
        /// </summary>
        /// <remarks>
        /// This operator is an alternative to both a full support
        /// for sparse tensor algebra, and for a full support of
        /// tensors in index expressions.
        ///
        /// The signature of this operator is:
        /// (I:int[m], E:float[n,k]) -> (S:float[m,k])
        ///
        /// It expects two tensors as inputs, the first one 'I' containing
        /// indices, the second one 'E' containing the embeddings. The
        /// operator returns the selection 'S' of embeddings matching the
        /// indices as defined by 'I'.
        /// </remarks>
        Embed
    }

    /// <summary>Abstract calculation that combines elements.
    /// Represents the right part of a statement of a tile.</summary>
    public class ElementExpression
    {
        public ArityKind ArityKind { get; }

        public UnaryExpressionKind UnaryKind { get; }

        public BinaryExpressionKind BinaryKind { get; }

        public Element Element { get; }

        public ElementExpression Expr1 { get; }

        public ElementExpression Expr2 { get; }

        public ElementExpression Expr3 { get; }

        public ElementExpression(Element element)
        {
            ArityKind = ArityKind.Element;
            UnaryKind = UnaryExpressionKind.None;
            BinaryKind = BinaryExpressionKind.None;

            Element = element;
        }

        public ElementExpression(UnaryExpressionKind kind, ElementExpression expr)
        {
            ArityKind = ArityKind.Unary;
            UnaryKind = kind;
            BinaryKind = BinaryExpressionKind.None;

            Expr1 = expr;
        }

        public ElementExpression(BinaryExpressionKind kind,
            ElementExpression expr1, ElementExpression expr2)
        {
            ArityKind = ArityKind.Binary;
            UnaryKind = UnaryExpressionKind.None;
            BinaryKind = kind;

            Expr1 = expr1;
            Expr2 = expr2;
        }

        public ElementExpression(ElementExpression test,
            ElementExpression ifTrue, ElementExpression ifFalse)
        {
            ArityKind = ArityKind.Ternary;
            UnaryKind = UnaryExpressionKind.None;
            BinaryKind = BinaryExpressionKind.None;

            Expr1 = test;
            Expr2 = ifTrue;
            Expr3 = ifFalse;
        }
    }
}