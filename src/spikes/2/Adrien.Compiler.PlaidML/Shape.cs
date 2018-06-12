using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Shape : PlaidMLApi<Shape>
    {
        #region Constructors
        public Shape(Context ctx, PlaidmlDatatype datatype, params int[] dimensions) : base(ctx)
        {
            ptr = plaidml.__Internal.PlaidmlAllocShape(context, datatype);
            if (ptr.IsZero())
            {
                ReportApiCallError("plaidml_alloc_shape");
                return;
            }
            else
            {
                IsAllocated = true;
                int stride = 1;
                for (int i = 0; i < dimensions.Length; i++)
                {
                    int dimension = dimensions[i];
                    stride *= dimension;
                }

                for (int i = 0; i < dimensions.Length; i++)
                {
                    int dimension = dimensions[i];
                    if (dimension != 0)
                    {
                        stride /= dimension;
                    }
                    this.AddDimension((ulong) dimension, stride);
                }
            }
        }

        public Shape(Context ctx, IntPtr p) : base(ctx)
        {
            this.ptr = p;
        }

        #endregion

        #region Overriden members
        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeShape(this);
        }
        #endregion

        #region Properties
        public PlaidmlDatatype DataType
        {
            get
            {
                ThrowIfNotAllocated();
                return plaidml.__Internal.PlaidmlGetShapeType(this);
            }
        }

        public ulong Offset
        {
            get
            {
                ThrowIfNotAllocated();
                ulong _Offset = plaidml.__Internal.PlaidmlGetShapeOffset(this);
                return _Offset;
            }
            set
            {
                ThrowIfNotAllocated();
                bool r = plaidml.__Internal.PlaidmlSetShapeOffset(this.context, this, value);
                if (!r)
                {
                    ReportApiCallError("plaidml_shape_offset");
            
                }
            }
        }

        public ulong DimensionCount
        {
            get
            {
                ThrowIfNotAllocated();
                return plaidml.__Internal.PlaidmlGetShapeDimensionCount(this);
            }
        }

        public List<(ulong size, long stride)> Dimensions
        {
            get
            {
                ThrowIfNotAllocated();
                if (this.DimensionCount == 0)
                {
                    return null;
                }
                return Enumerable.Range(0, (int)this.DimensionCount)
                    .Select(i => (GetDimensionSize((ulong)i), GetDimensionStride((ulong)i))).ToList();
            }
        }

        #endregion

        #region Methods
        public long GetDimensionStride(ulong dimension)
        {
            return plaidml.__Internal.PlaidmlGetShapeDimensionStride(this, dimension);
        }

        public ulong GetDimensionSize(ulong dimension)
        {
            return plaidml.__Internal.PlaidmlGetShapeDimensionSize(this, dimension);
        }

        public bool AddDimension(ulong size, long stride)
        {
            ThrowIfNotAllocated();
            bool r = plaidml.__Internal.PlaidmlAddDimension(context, this, size, stride);
            if (!r)
            {
                ReportApiCallError("plaidml_add_dimension");
            }
            return r;
        }
        #endregion

        #region Operators
        public (ulong size, long stride) this[int i]
        {
            get
            {
                ThrowIfNotAllocated();
                return Dimensions[i];
            }
        }
        #endregion
    }
}
