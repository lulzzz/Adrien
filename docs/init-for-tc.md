# Automatic Initialization for Tensor Comprehensions

> By Joannes Vermorel, May 2018

Pretty maths at http://media.lokad.com/adrien/init-for-tc.html

STATUS: **EARLY DRAFT**

**Abstract:** Tensor Comprehensions (TC) are of primary interests for Differentiable Programming (DP). As TCs are more versatile than their static kernel counterparts, the random initialization of the tensors involved in TC proves more challenging as well. We present a method for the automatic initialization of the parameter tensors within TCs. The method aims are present unit Gaussians for all flow tensors. The method shares similarities with the forward automatic differentiation.

## Overview

The deep learning literature suggests to initialize the model parameters randomly within the network following a Gaussian $\mathcal{N}(0, 1)$. However, when this heuristic is used alone, it proves insufficient as ubiquitous operations such as matrix multiplications inflate the variance of the inputs if the matrix parameters are drawn from $\mathcal{N}(0, 1)$. When those operations are chained through a _deep_ network, numerical instabilities ensue, and the SGD stops working.

Deep learning toolkits are typically [^1] [^2] [^5] introducing a set of handcrafted parameter initializers to deal the problem. The initializers are manually adjusted to fit specific "layers". Every layer needs its own initializer to avoid undesirable numerical behaviors. This approach is tedious and goes somewhat against the design principle of differential programming of having the SGD fully automated.

## Preserving unit Gaussians

From the deep learning perspective, if we assume that the inputs are drawn from $\mathcal{N}(0, 1)$, the purpose of the weight initializers is to preserve a variance of 1 for the values obtained as inputs of the next layer.

Let's clarify this intent from a differentiable programming perspective driven by tensor comprehensions:

> For any given tensor comprehensions, if we assume that input tensors have their values drawn from $\mathcal{N}(0,1)$ then the initialization of the parameter tensors should ensure that law governing the output tensors should remain as close as possible to $\mathcal{N}(0,1)$ from a cross-entropy perspective.

Our criterion is more stringent that the plain _conservation-of-variance_ heuristic, we don't merely seek a properly sized variance, we seek distributions that remain essentially similar to the unit Gaussian.

## An illustrative example
Let's start with a matrix-vector product defined following the _Facebook Tensor Comprehensions_ syntax:

    def mv(float(M,N) A, float(N) B) → (C) {
      C(i) +=! A(i,j) * B(j)
    }

Here, `A` is the parameter to be randomly initialized and `B` the input, assumed to be drawn from $\mathcal{N}(0,1)$.

The product [^3] of two Gaussians gives:

$$\mathcal{N}(\mu_1, \sigma_1^2) \times \mathcal{N}(\mu_2, \sigma_2^2) = \mathcal{N}\left(\frac{\sigma_1^2 \mu_2 + \sigma_2^2 \mu_1}{\sigma_1^2 + \sigma_2^2},\frac{1}{\frac{1}{\sigma_1^2} + \frac{1}{\sigma_2^2}}\right)$$

Thus, 

$$\mathcal{N}(0, 1) \times \mathcal{N}(0, 1) = \mathcal{N}\left(0,\frac{1}{2}\right)$$

Similarly, the sum [^4] of two Gaussians gives:

$$\mathcal{N}(\mu_1, \sigma_1^2) + \mathcal{N}(\mu_2, \sigma_2^2) = \mathcal{N}\left(\mu_1 + \mu_2, \sigma_1^2 + \sigma_2^2\right)$$

Thus,

$$\mathcal{N}(0, 1) + \mathcal{N}(0, 1) = \mathcal{N}(0,2)$$

By applying the logic above, we see that the `mv` TC above has:

$$\texttt{mv} : \mathcal{N}(0, 1) \to \mathcal{N}\left(0, \frac{1}{2} \texttt{N}\right) $$

Thus, by rescaling the parameters of `A` by the factor $\sqrt{2/\mathtt{N}}$, we put the results back into $\mathcal{N}(0, 1)$.

At this point, we have two important operators covered: the addition and the product. This is the foundation of the intuition for the next section.

## Automatic shaping of initial parameters

We propose to have the parameter initialization automatically shaped to reflect the criterion proposed above. By _automatically_, we refer to a process fundamentally similar to the one performed for the automatic differentiation: a transformation of the sequence of instructions leading to the desired result.

We introduce an algebra over $\mathbb{R}^2$ implicitly reflecting the pair $(\mu, \sigma^2)$ of the mean and the variance. In the following, we refer to those pairs as _bells_. As detailed above, we have already the rules for the addition and the product. For any operator that do not benefit from a known formula, it is still possible to use a Monte-Carlo process and find the most fitting Gaussian on the result. As Monte-Carlo is computationally expensive, it makes sense to train parametric representations ahead of time (instead of trying to perform simulations on the fly).

For every parameter tensor of computational network, we seek to compute the bell that delivers the expected behavior - per rule introduced above.

By replacing the tensor values by their bells counterpart, just like it is done with _forward automatic differentiation_ with dual numbers,we propagate bells through the tensor comprehension.

The automatic shaping works as follow:

1. initialize all parameter tensors with bells at `(0, 1)`.
2. initialize all input tensors with bells at `(0, 1)`.
3. move to next operation
4. propagate bells through current operation
5. if current operation has no parameter tensor, go to 3.
6. if resulting flow tensor is not  `(0, 1)`, re-shape parameter tensors to yield `(0, 1)` (or approximate)


## References

[^1]: CNTK documentation, initializers of parameters  https://www.cntk.ai/pythondocs/cntk.initializer.html

[^2]: PyTorch source code, initialization logic https://pytorch.org/docs/master/_modules/torch/nn/init.html

[^3]: https://ccrma.stanford.edu/~jos/sasp/Product_Two_Gaussian_PDFs.html

[^4]: https://en.wikipedia.org/wiki/Sum_of_normally_distributed_random_variables

[^5]: _Understanding the difficulty of training deep feedforward neural networks_, 2010, Xavier Glorot, Yoshua Bengio http://proceedings.mlr.press/v9/glorot10a/glorot10a.pdf