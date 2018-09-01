using System;

namespace Adrien.Ast
{
    public enum IndexExpressionArityKind
    {
        Constant,
        Index,
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
    /// <remarks>
    /// An 'IndexExpression' allows at most a single multidimensional
    /// index. If several of such indices are found, the expression is
    /// invalid.
    ///
    /// When an 'IndexExpression' contains a multidimensional index,
    /// then the expression is interpreted as a sequence of index
    /// expressions, each one associated with each subindex of the
    /// original multidimensional index.
    /// </remarks>
    public class IndexExpression
    {
        public IndexExpressionArityKind ArityKind { get; }

        public BinaryExpressionKind BinaryKind { get; }

        public int Constant { get; }

        public Index Index { get; }

        public IndexExpression Expr1 { get; }

        public IndexExpression Expr2 { get; }

        public IndexExpression(int constant)
        {
            ArityKind = IndexExpressionArityKind.Constant;
            BinaryKind = BinaryExpressionKind.None;
            Constant = constant;
        }

        public IndexExpression(Index index)
        {
            ArityKind = IndexExpressionArityKind.Index;
            BinaryKind = BinaryExpressionKind.None;
            Index = index ?? throw new ArgumentNullException(nameof(index));
        }

        public IndexExpression(BinaryExpressionKind kind,
            IndexExpression expr1, IndexExpression expr2)
        {
            ArityKind = IndexExpressionArityKind.Binary;
            BinaryKind = kind;
            Expr1 = expr1 ?? throw new ArgumentNullException(nameof(expr1));
            Expr2 = expr2 ?? throw new ArgumentNullException(nameof(expr2));
        }
    }
}