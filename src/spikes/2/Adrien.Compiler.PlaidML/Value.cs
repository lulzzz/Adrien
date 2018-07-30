using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Value : PlaidMLApi<Value>
    {
        public string Name { get; protected set; }

        protected Value(Context ctx) : base(ctx) {}

        protected Value(Context ctx, string name) : this(ctx)
        {
            this.Name = name;
        }

        public Value(Context ctx, string name, IntPtr varPtr) : base(ctx)
        {
            if (varPtr.IsZero())
            {
                throw new ArgumentNullException("varPtr");
            }
            this.ptr = varPtr;
            this.Name = name;
            IsAllocated = true;
        }

        public Value(Variable variable) : base(variable.Context)
        {
            this.ptr = variable.VarPtr;
            this.Name = variable.Name;
            IsAllocated = true;
        }

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeVar(ptr);
            ptr = IntPtr.Zero;
        }
    }
}
