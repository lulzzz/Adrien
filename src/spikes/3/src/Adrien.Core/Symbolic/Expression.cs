using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
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

    /// <summary>Abstract calculation that combines indexed symbols.
    /// Represents the right part of a statement with a flow.</summary>
    public class Expression
    {
        public ArityKind ArityKind { get; set; }

        public UnaryExpressionKind UnaryKind { get; set; }

        public BinaryExpressionKind BinaryKind { get; set; }

        public IReadOnlyList<IndexedSymbol> Symbols
        {
            get {  throw new NotImplementedException(); }
        }

        public Expression(IndexedSymbol indexed)
        {
            ArityKind = ArityKind.Term;

            throw new NotImplementedException();
        }

        public Expression(UnaryExpressionKind kind, Expression expr)
        {
            ArityKind = ArityKind.Unary;
            UnaryKind = kind;

            throw new NotImplementedException();
        }

        public Expression(BinaryExpressionKind kind, Expression expr1, Expression expr2)
        {
            ArityKind = ArityKind.Binary;
            BinaryKind = kind;

            throw new NotImplementedException();
        }

        public Expression(Expression test, Expression ifTrue, Expression ifFalse)
        {
            ArityKind = ArityKind.Ternary;

            throw new NotImplementedException();
        }
    }
}
