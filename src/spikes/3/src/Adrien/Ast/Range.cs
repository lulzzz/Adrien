﻿namespace Adrien.Ast
{
    /// <summary>
    /// A range is the geometric characterization of an index
    /// within a statement of a tile.
    /// </summary>
    public class Range
    {
        public int Offset { get; }

        public int Count { get; }

        public Range(int offset, int count)
        {
            Offset = offset;
            Count = count;
        }
    }
}
