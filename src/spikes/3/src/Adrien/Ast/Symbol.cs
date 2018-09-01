using System;

namespace Adrien.Ast
{
    /// <summary>
    /// Identifies a calculation variable at the tile level.
    /// </summary>
    public class Symbol
    {
        private Shape _shape;

        public string Name { get; }

        /// <summary>
        /// Position of the symbol with the argument list passed to the
        /// kernel at evaluation time.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        public Shape Shape
        {
            get => _shape;
            set
            {
                if (_shape != null)
                    throw new InvalidOperationException("Shape is monotonous and cannot be reassigned.");

                _shape = value;
            }
        }

        public Symbol(string name, int position)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if(position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));

            Name = name;
            Position = position;
        }
    }
}