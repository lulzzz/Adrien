using System;
using System.Collections.Generic;
using System.Linq;

using Adrien.Compiler.PlaidML.Bindings;

namespace Adrien.Compiler.PlaidML
{
    public class Shape : PlaidMLApi<Shape>
    {
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
                return plaidml.__Internal.PlaidmlGetShapeOffset(this);
            }
            set
            {
                ThrowIfNotAllocated();
                bool r = plaidml.__Internal.PlaidmlSetShapeOffset(this.context, this, value);
                if (!r)
                {
                    ReportApiCallError("plaidml_shape_offset");
                    throw new Exception("Could not set shape offset.");
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

        public ulong ElementCount
        {
            get
            {
                ThrowIfNotAllocated();
                return plaidml.__Internal.PlaidmlGetShapeElementCount(this);
            }
        }

        public List<(ulong length, long stride)> Dimensions
        {
            get
            {
                ThrowIfNotAllocated();
                if (this.DimensionCount == 0)
                {
                    return null;
                }
                return Enumerable.Range(0, (int)this.DimensionCount)
                    .Select(i => (GetDimensionLength((ulong)i), GetDimensionStride((ulong)i))).ToList();
            }
        }
        
      
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
                    this.AddDimension((ulong)dimension, stride);
                }
            }
        }

        public Shape(Context ctx, IntPtr p) : base(ctx)
        {
            this.ptr = p;
            IsAllocated = true;
        }

        
        public (ulong length, long stride) this[int i]
        {
            get
            {
                ThrowIfNotAllocated();
                return Dimensions[i];
            }
        }

        public static PlaidmlDatatype ToDataType<T>() where T : unmanaged
        {
            PlaidmlDatatype datatype = PlaidmlDatatype.PLAIDML_DATA_INVALID;
            T t = default;
            switch (t)
            {
                case Boolean _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_BOOLEAN;
                    break;

                case SByte _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_INT8;
                    break;

                case Byte _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_UINT8;
                    break;

                case Int16 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_INT16;
                    break;

                case UInt16 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_UINT16;
                    break;

                case Int32 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_INT32;
                    break;

                case UInt32 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_UINT32;
                    break;

                case Int64 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_INT64;
                    break;

                case UInt64 _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_UINT64;
                    break;

                case float _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_FLOAT32;
                    break;

                case Double _:
                    datatype = PlaidmlDatatype.PLAIDML_DATA_FLOAT64;
                    break;
                default:
                    throw new Exception($"This .NET type is not supported as a PlaidML datatype:{typeof(T).Name}");
            }
            return datatype;
        }

        public override void Free()
        {
            base.Free();
            plaidml.__Internal.PlaidmlFreeShape(this);
        }
        
        public long GetDimensionStride(ulong dimension)
        {
            return plaidml.__Internal.PlaidmlGetShapeDimensionStride(this, dimension);
        }

        public ulong GetDimensionLength(ulong dimension)
        {
            return plaidml.__Internal.PlaidmlGetShapeDimensionSize(this, dimension);
        }

        public bool AddDimension(ulong length, long stride)
        {
            ThrowIfNotAllocated();
            bool r = plaidml.__Internal.PlaidmlAddDimension(context, this, length, stride);
            if (!r)
            {
                ReportApiCallError("plaidml_add_dimension");
            }
            return r;
        }
    }
}
