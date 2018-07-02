using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public enum TensorOp
    {
        NoOp,
        Assign,
        Summation,
        Log,
        Log10,
        Add,
        AddCons,
        Sub,
        SubCons,
        Mul,
        Div,
        Sin,
        Cos,
    }
}
