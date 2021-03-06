﻿using System;
using System.Collections.Generic;

namespace Adrien.Ast
{
    /// <summary>
    /// Multidimensional index intended for Einstein notations.
    /// </summary>
    /// <remarks>
    /// The index is referred as unidimensional if 'Ranges' has
    /// a count of 1. The index is referred as multidimensional
    /// if count is greater than 1.
    /// 
    /// The index can be multidimensional in order to facilitate
    /// generic notations where the rank of the symbol is not
    /// known prior to the geometric inference.
    /// </remarks>
    public class Index
    {
        private IReadOnlyList<Range> _ranges;

        public string Name { get; }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        /// <remarks>
        /// Backend implementations are intended to only use 'Range' rather
        /// than 'Ranges'. Indeed, by applying a prior transformation on the
        /// tile, all the complex indices can be turned into simple ones.
        /// </remarks>
        public Range Range
        {
            get
            {
                if (Ranges.Count > 1)
                    throw new InvalidOperationException("Range not accessible in a complex Index.");

                return Ranges[0];
            }
            set
            {
                if (_ranges != null)
                    throw new InvalidOperationException("Range is monotonous and cannot be reassigned.");

                Ranges = new[] {value};
            }
        }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        public IReadOnlyList<Range> Ranges
        {
            get => _ranges;
            set
            {
                if (_ranges != null)
                    throw new InvalidOperationException("Ranges is monotonous and cannot be reassigned.");

                _ranges = value;
            }
        }

        public Index(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
        }
    }
}