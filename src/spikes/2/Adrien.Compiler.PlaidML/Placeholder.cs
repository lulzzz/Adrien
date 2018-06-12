using System;
using System.Collections.Generic;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Placeholder : Variable
    {
        #region Constructors
        public Placeholder(Context ctx, ulong dimensionCount) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocPlaceholder(dimensionCount); 
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_placeholder");
            }
            else
            {
                IsAllocated = true;
                DimensionCount = dimensionCount;
            }
        }
        #endregion

        #region Properties
        public ulong DimensionCount { get; protected set; }
        #endregion
    }
}
