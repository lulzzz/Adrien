﻿using Adrien.Ast;

namespace Adrien.Numerics
{
    /// <summary>
    /// Intended to be inherited by backend implementations for Adrien.
    /// </summary>
    public interface ITileCompiler
    {
        /// <summary>
        /// Compiles a tile into a kernel. The tile is expected to
        /// be geometrically fully inferred - i.e. all symbols have
        /// a shape, all indices have ranges.
        /// </summary>
        IKernel Compile(Tile tile);
    }
}
