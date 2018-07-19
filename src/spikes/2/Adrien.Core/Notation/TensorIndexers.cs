using System.Linq.Expressions;

namespace Adrien.Notation
{
	public partial class Tensor
	{
		  
		public TensorExpression this[Index index1]
		{
			get
			{
				ThrowIfIndicesExceedRank(1);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[] 
				{this}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2]
		{
			get
			{
				ThrowIfIndicesExceedRank(2);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,] 
				{{this}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3]
		{
			get
			{
				ThrowIfIndicesExceedRank(3);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,] 
				{{{this}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4]
		{
			get
			{
				ThrowIfIndicesExceedRank(4);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,] 
				{{{{this}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name), 
					Expression.Parameter(typeof(int), index4.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3, index4), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5]
		{
			get
			{
				ThrowIfIndicesExceedRank(5);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,] 
				{{{{{this}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name), 
					Expression.Parameter(typeof(int), index4.Name), 
					Expression.Parameter(typeof(int), index5.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3, index4, index5), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6]
		{
			get
			{
				ThrowIfIndicesExceedRank(6);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,] 
				{{{{{{this}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name), 
					Expression.Parameter(typeof(int), index4.Name), 
					Expression.Parameter(typeof(int), index5.Name), 
					Expression.Parameter(typeof(int), index6.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3, index4, index5, index6), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7]
		{
			get
			{
				ThrowIfIndicesExceedRank(7);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,] 
				{{{{{{{this}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name), 
					Expression.Parameter(typeof(int), index4.Name), 
					Expression.Parameter(typeof(int), index5.Name), 
					Expression.Parameter(typeof(int), index6.Name), 
					Expression.Parameter(typeof(int), index7.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7), value);
			}
		}
		  
		public TensorExpression this[Index index1, Index index2, Index index3, Index index4, Index index5, Index index6, Index index7, Index index8]
		{
			get
			{
				ThrowIfIndicesExceedRank(8);
				return new TensorExpression(Expression.ArrayAccess
					(Expression.Constant(new Tensor[,,,,,,,] 
				{{{{{{{{this}}}}}}}}), 
				new Expression[] {
					Expression.Parameter(typeof(int), index1.Name), 
					Expression.Parameter(typeof(int), index2.Name), 
					Expression.Parameter(typeof(int), index3.Name), 
					Expression.Parameter(typeof(int), index4.Name), 
					Expression.Parameter(typeof(int), index5.Name), 
					Expression.Parameter(typeof(int), index6.Name), 
					Expression.Parameter(typeof(int), index7.Name), 
					Expression.Parameter(typeof(int), index8.Name)}));
			}
			set
			{
				ThrowIfAlreadyAssiged();
				Assignment = (new IndexSet(this, index1, index2, index3, index4, index5, index6, index7, index8), value);
			}
		}
			}
}