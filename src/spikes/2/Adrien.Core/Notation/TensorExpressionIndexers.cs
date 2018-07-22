using System;
using System.Linq.Expressions;

namespace Adrien.Notation
{
	public partial class TensorExpression
	{
		  
		public TensorExpression this[Index index1]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3, index4];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3, index4] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3, index4, index5];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3, index4, index5] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3, index4, index5, index6];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3, index4, index5, index6] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3, index4, index5, index6, index7];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3, index4, index5, index6, index7] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7, Index index8]
		{
			get
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    return t[index1, index2, index3, index4, index5, index6, index7, index8];
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
			set
			{
				if (this.LinqExpression.NodeType == ExpressionType.Constant &&
                    (this.LinqExpression as ConstantExpression).Type == typeof(Tensor))
                {
                    Tensor t = (this.LinqExpression as ConstantExpression).Value as Tensor;
                    t[index1, index2, index3, index4, index5, index6, index7, index8] = value;
                }
                else throw new ArgumentException("This expression is not a tensor;");
			}
		}
			}
}