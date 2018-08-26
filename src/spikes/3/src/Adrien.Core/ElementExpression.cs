using System;
using System.Collections.Generic;

namespace Adrien.Core
{
    public enum ArityKind
    {
        Term,
        Unary,
        Binary,
        Ternary
    }

    public enum UnaryExpressionKind
    {
        Exp,
        Log
    }

    public enum BinaryExpressionKind
    {
        Add,
        Subtract,
        Multiple,
        Divide
    }

    /// <summary>Abstract calculation that combines elements.
    /// Represents the right part of a statement of a tile.</summary>
    public class ElementExpression
    {
        public ArityKind ArityKind { get; set; }

        public UnaryExpressionKind UnaryKind { get; set; }

        public BinaryExpressionKind BinaryKind { get; set; }

        public IReadOnlyList<Element> Symbols
        {
            get {  throw new NotImplementedException(); }
        }

        public ElementExpression(Element indexed)
        {
            ArityKind = ArityKind.Term;

            throw new NotImplementedException();
        }

        public ElementExpression(UnaryExpressionKind kind, ElementExpression expr)
        {
            ArityKind = ArityKind.Unary;
            UnaryKind = kind;

            throw new NotImplementedException();
        }

        public ElementExpression(BinaryExpressionKind kind, ElementExpression expr1, ElementExpression expr2)
        {
            ArityKind = ArityKind.Binary;
            BinaryKind = kind;

            throw new NotImplementedException();
        }

        public ElementExpression(ElementExpression test, ElementExpression ifTrue, ElementExpression ifFalse)
        {
            ArityKind = ArityKind.Ternary;

            throw new NotImplementedException();
        }
    }
}
