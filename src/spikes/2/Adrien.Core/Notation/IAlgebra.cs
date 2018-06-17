using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public interface IAlgebra<TTerm> where TTerm : Term
    {
        TTerm Negate(TTerm left);
        TTerm Add(TTerm left, TTerm right);
        TTerm Sub(TTerm left, TTerm right);
        TTerm Mul(TTerm left, TTerm right);
        TTerm Div(TTerm left, TTerm right);
    }
}
