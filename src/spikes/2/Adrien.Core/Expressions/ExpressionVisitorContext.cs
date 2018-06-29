using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

using Adrien.Trees;

namespace Adrien
{
    public class ExpressionVisitorContext : TreeBuilderContext
    {
        public ExpressionVisitorContext(ExpressionTree tree) : base(tree) {}
    }
}
