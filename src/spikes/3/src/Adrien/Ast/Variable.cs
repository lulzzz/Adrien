using System;

namespace Adrien.Ast
{
    /// <summary>
    /// Identify a variable at the graph level.
    /// </summary>
    public class Variable
    {
        private Shape _shape;

        public string Name { get; }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        public Shape Shape
        {
            get => _shape;
            set
            {
                if (_shape != null)
                    throw new InvalidOperationException("Variable.Shape is monotonous and cannot be reassigned.");

                _shape = value;
            }
        }

        public bool IsInput { get; }

        public bool IsOutput { get; }

        public bool IsCriterion { get; }

        public Variable(string name, bool isInput, bool isOutput, bool isCriterion)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
            IsInput = isInput;
            IsOutput = isOutput;
            IsCriterion = isCriterion;
        }
    }
}
