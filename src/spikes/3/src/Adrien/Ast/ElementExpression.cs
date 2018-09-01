using System;

namespace Adrien.Ast
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

            Element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public ElementExpression(UnaryExpressionKind kind, ElementExpression expr)
        {
            ArityKind = ArityKind.Unary;
            UnaryKind = kind;
            BinaryKind = BinaryExpressionKind.None;

            Expr1 = expr ?? throw new ArgumentNullException(nameof(expr));
        }

        public ElementExpression(BinaryExpressionKind kind,
            ElementExpression expr1, ElementExpression expr2)
        {
            ArityKind = ArityKind.Binary;
            UnaryKind = UnaryExpressionKind.None;
            BinaryKind = kind;

            Expr1 = expr1 ?? throw new ArgumentNullException(nameof(expr1));
            Expr2 = expr2 ?? throw new ArgumentNullException(nameof(expr2));
        }

        public ElementExpression(ElementExpression test,
            ElementExpression ifTrue, ElementExpression ifFalse)
        {
            ArityKind = ArityKind.Ternary;
            UnaryKind = UnaryExpressionKind.None;
            BinaryKind = BinaryExpressionKind.None;

            Expr1 = test ?? throw new ArgumentNullException(nameof(test));
            Expr2 = ifTrue ?? throw new ArgumentNullException(nameof(ifTrue));
            Expr3 = ifFalse ?? throw new ArgumentNullException(nameof(ifFalse));
        }
    }
}