﻿using System;

namespace Adrien.Ast
{
    public enum StatementKind
    {
        Assign,
        Sum,
        Max,
        AddSum,
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
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}