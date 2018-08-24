namespace Adrien.Core.Symbolic
{
    /// <summary>
    /// Identifies a variable that behave like a tensor,
    /// but leaving the shape unspecified.
    /// </summary>
    public class Symbol
    {
        public string Name { get; set; }

        public Symbol(string name)
        {
            Name = name;
        }
    }
}
