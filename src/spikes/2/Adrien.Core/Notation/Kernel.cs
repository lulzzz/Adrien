using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    public class Kernel<TDelegate> where TDelegate : Delegate
    {
        public Kernel(Expression<TDelegate> e)
        {
            Expression = e;
        }

        protected Expression<TDelegate> Expression { get; set; }

        public static implicit operator Kernel<TDelegate>(Expression<TDelegate> expr) 
        {
            return new Kernel<TDelegate>(expr);
        }

        
    }
}
