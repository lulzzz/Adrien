namespace Adrien.Core
{
    /// <summary>
    /// Identify a variable at the graph level.
    /// </summary>
    public class Variable
    {
        public string Name { get; }

        /// <summary>
        /// Late assignment at geometric inference.
        /// </summary>
        public Shape Shape { get; set; }

        public bool IsInput { get; set; }

        public bool IsOutput { get; set; }

        public bool IsCriterion { get; set; }

        public Variable(string name)
        {
            Name = name;
        }
    }
}
