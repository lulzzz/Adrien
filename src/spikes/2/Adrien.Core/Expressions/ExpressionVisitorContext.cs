using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Trees;

namespace Adrien
{
    public class ExpressionVisitorContext : TreeVisitorContext<Op, Expression>
    {
        public ExpressionVisitorContext(ExpressionTree tree) : base(tree)
        {
            
        }
    }
}
