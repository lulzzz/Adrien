using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public interface IAlgebra<TTerm> where TTerm : ITerm
    {
        TTerm Negate();
        TTerm Add(TTerm right);
        TTerm Subtract(TTerm right);
        TTerm Multiply(TTerm right);
        TTerm Divide(TTerm right);
    }
}
