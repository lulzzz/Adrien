using System;

namespace Adrien.Fluent
{
    /// <summary>
    /// A symbol when operating at the graph level.
    /// </summary>
    public class FVariable
    {
        public FVariable()
        {
        }

        public FVariable As(string name)
        {
            throw new NotImplementedException();
        }

        public FVariable AsInput()
        {
            throw new NotImplementedException();
        }

        public FVariable AsOutput()
        {
            throw new NotImplementedException();
        }

        public FVariable AsCriterion()
        {
            throw new NotImplementedException();
        }

        public FVariable AsScalar()
        {
            throw new NotImplementedException();
        }

        public FVariable As1D(int dimension)
        {
            throw new NotImplementedException();
        }

        public FVariable As2D(int dim1, int dim2)
        {
            throw new NotImplementedException();
        }
    }
}
