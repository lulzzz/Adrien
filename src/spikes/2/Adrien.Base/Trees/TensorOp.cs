using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Trees
{
    public enum TensorOp
    {
        NoOp,
        Sum,
        Square,
        Assign,
        ElementWiseAssign,
        Index,
        Log,
        Log10,
        Add,
        AddCons,
        Sub,
        SubCons,
        Mul,
        Pow,
        Div,
        Sin,
        Cos,
    }
}
