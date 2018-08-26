namespace Adrien.Core
{
    /// <summary>
    /// Identify a variable at the graph level.
    /// </summary>
    public class Variable
    {
        public string Name { get; set; }

        public Shape Shape { get; set; }

        public bool IsInput { get; }

        public bool IsOutput { get; }

        public bool IsCriterion { get; }

        public Variable(string name)
        {
            Name = name;
        }
    }
}
