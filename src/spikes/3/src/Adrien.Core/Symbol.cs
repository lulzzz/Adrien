namespace Adrien.Core
{   
    /// <summary>
    /// Identifies a calculation variable at the tile level.
    /// </summary>
    public class Symbol
    {
        public string Name { get; }

        public Shape Shape { get; set; }

        public Symbol(string name)
        {
            Name = name;
        }
    }
}
