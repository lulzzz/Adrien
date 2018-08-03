using System.Linq.Expressions;

namespace Adrien.Notation
{
	public partial class Tensor
	{
		  
		public TensorIndexExpression this[Index index1]
		{
			get
			{
				ThrowIfIndicesExceedRank(1);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[] 
				{this}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1]
		{
			get
			{
				ThrowIfIndicesExceedRank(1);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[] 
				{this}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2]
		{
			get
			{
				ThrowIfIndicesExceedRank(2);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,] 
				{{this}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2]
		{
			get
			{
				ThrowIfIndicesExceedRank(2);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,] 
				{{this}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3]
		{
			get
			{
				ThrowIfIndicesExceedRank(3);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,] 
				{{{this}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3]
		{
			get
			{
				ThrowIfIndicesExceedRank(3);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,] 
				{{{this}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3, Index index4]
		{
			get
			{
				ThrowIfIndicesExceedRank(4);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,] 
				{{{{this}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id), 
					Expression.Parameter(typeof(int), index4.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3, DimensionExpression dim4]
		{
			get
			{
				ThrowIfIndicesExceedRank(4);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,] 
				{{{{this}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id), 
					Expression.Parameter(typeof(int), dim4.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3, Index index4, Index index5]
		{
			get
			{
				ThrowIfIndicesExceedRank(5);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,] 
				{{{{{this}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id), 
					Expression.Parameter(typeof(int), index4.Id), 
					Expression.Parameter(typeof(int), index5.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3, DimensionExpression dim4, DimensionExpression dim5]
		{
			get
			{
				ThrowIfIndicesExceedRank(5);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,] 
				{{{{{this}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id), 
					Expression.Parameter(typeof(int), dim4.Id), 
					Expression.Parameter(typeof(int), dim5.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6]
		{
			get
			{
				ThrowIfIndicesExceedRank(6);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,] 
				{{{{{{this}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id), 
					Expression.Parameter(typeof(int), index4.Id), 
					Expression.Parameter(typeof(int), index5.Id), 
					Expression.Parameter(typeof(int), index6.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3, DimensionExpression dim4, DimensionExpression dim5, DimensionExpression dim6]
		{
			get
			{
				ThrowIfIndicesExceedRank(6);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,] 
				{{{{{{this}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id), 
					Expression.Parameter(typeof(int), dim4.Id), 
					Expression.Parameter(typeof(int), dim5.Id), 
					Expression.Parameter(typeof(int), dim6.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7]
		{
			get
			{
				ThrowIfIndicesExceedRank(7);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,] 
				{{{{{{{this}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id), 
					Expression.Parameter(typeof(int), index4.Id), 
					Expression.Parameter(typeof(int), index5.Id), 
					Expression.Parameter(typeof(int), index6.Id), 
					Expression.Parameter(typeof(int), index7.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3, DimensionExpression dim4, DimensionExpression dim5, DimensionExpression dim6, DimensionExpression dim7]
		{
			get
			{
				ThrowIfIndicesExceedRank(7);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,] 
				{{{{{{{this}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id), 
					Expression.Parameter(typeof(int), dim4.Id), 
					Expression.Parameter(typeof(int), dim5.Id), 
					Expression.Parameter(typeof(int), dim6.Id), 
					Expression.Parameter(typeof(int), dim7.Id)}));
			}
		}
		  
		public TensorIndexExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7, Index index8]
		{
			get
			{
				ThrowIfIndicesExceedRank(8);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,,] 
				{{{{{{{{this}}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Id), 
					Expression.Parameter(typeof(int), index2.Id), 
					Expression.Parameter(typeof(int), index3.Id), 
					Expression.Parameter(typeof(int), index4.Id), 
					Expression.Parameter(typeof(int), index5.Id), 
					Expression.Parameter(typeof(int), index6.Id), 
					Expression.Parameter(typeof(int), index7.Id), 
					Expression.Parameter(typeof(int), index8.Id)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				if (value.LinqExpression.NodeType == ExpressionType.Call)
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7, index8), value as TensorContraction);
                }
                else
                {
                    ContractionDefinition = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7, index8), Math.SigmaSum(value));
                }
			}
		}

		public TensorIndexExpression this[DimensionExpression dim1, DimensionExpression dim2, DimensionExpression dim3, DimensionExpression dim4, DimensionExpression dim5, DimensionExpression dim6, DimensionExpression dim7, DimensionExpression dim8]
		{
			get
			{
				ThrowIfIndicesExceedRank(8);
				return new TensorIndexExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,,] 
				{{{{{{{{this}}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), dim1.Id), 
					Expression.Parameter(typeof(int), dim2.Id), 
					Expression.Parameter(typeof(int), dim3.Id), 
					Expression.Parameter(typeof(int), dim4.Id), 
					Expression.Parameter(typeof(int), dim5.Id), 
					Expression.Parameter(typeof(int), dim6.Id), 
					Expression.Parameter(typeof(int), dim7.Id), 
					Expression.Parameter(typeof(int), dim8.Id)}));
			}
		}
			}
}