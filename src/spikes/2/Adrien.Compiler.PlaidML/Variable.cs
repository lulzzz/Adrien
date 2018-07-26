using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Variable : PlaidMLApi<Variable>
    {
        public string Name { get; protected set; }

        public PlaidmlDatatype DataType { get; protected set; }
        

        protected Variable(Context ctx) : base(ctx) { }
  
        protected Variable(Context ctx, string name) : base(ctx)
        {
            Name = name;
        }

        protected Variable(IntPtr varPtr, string name, Context ctx) : base(ctx)
        {
            ptr = varPtr;
            Name = name;
        }

        public Variable(Context ctx, string name, Int64 v) : this(ctx, name)
        {
            ptr = plaidml.__Internal.PlaidmlAllocInt64(v);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_int64");
                return;
            }
            else
            {
                DataType = PlaidmlDatatype.PLAIDML_DATA_INT64;
                IsAllocated = true;
            }
        }

        public Variable(Context ctx, string name, Int32 v) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocInt64(v);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_int64");
                return;
            }
            else
            {
                DataType = PlaidmlDatatype.PLAIDML_DATA_INT64;
                IsAllocated = true;
            }
        }

        public Variable(Context ctx, string name, double v) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocReal(v);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_real");
                return;
            }
            else
            {
                Name = name;
                DataType = PlaidmlDatatype.PLAIDML_DATA_FLOAT64;
                IsAllocated = true;
            }
        }

        public Variable(Context ctx, string name, float v) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocReal(v);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_real");
                return;
            }
            else
            {
                Name = name;
                DataType = PlaidmlDatatype.PLAIDML_DATA_FLOAT64;
                IsAllocated = true;
            }
        }
      

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeVar(ptr);
            ptr = IntPtr.Zero;
        }
    }
}
