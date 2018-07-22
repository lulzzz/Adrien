using System.Linq.Expressions;

namespace Adrien.Notation
{
	public partial class Tensor
	{
		  
		public TensorExpression this[Tensor tensor1]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3, Tensor tensor4]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3, tensor4}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3, Tensor tensor4, Tensor tensor5]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3, tensor4, tensor5}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3, Tensor tensor4, Tensor tensor5, Tensor tensor6]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3, tensor4, tensor5, tensor6}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3, Tensor tensor4, Tensor tensor5, Tensor tensor6, Tensor tensor7]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3, tensor4, tensor5, tensor6, tensor7}, value);
			}
		}
		  
		public TensorExpression this[Tensor tensor1, Tensor tensor2, Tensor tensor3, Tensor tensor4, Tensor tensor5, Tensor tensor6, Tensor tensor7, Tensor tensor8]
		{
			get => this;
			set
			{
				ThrowIfAlreadyAssiged();
				ElementwiseAssignment = (new Tensor[] { tensor1, tensor2, tensor3, tensor4, tensor5, tensor6, tensor7, tensor8}, value);
			}
		}
			}
}