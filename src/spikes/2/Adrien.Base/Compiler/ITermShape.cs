using System.Collections.Generic;

namespace Adrien.Compiler
{
    public interface ITermShape : IShape, ITerm, IEnumerable<int>
    {
    }
}