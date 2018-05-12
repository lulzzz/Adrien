# Automatic Differentiation for Tensor Comprehensions

> By Joannes Vermorel, May 12th, 2018

Pretty maths at http://media.lokad.com/adrien/ad-for-tc.html

STATUS: **EARLY DRAFT**

**Abstract:** Automatic differentiation (AD) and tensor comprehensions (TC) are both of primary interest for differentiable programming. Here, we show how automatic differentiation can be seen as a compiler _transformation_ from TC to TC. The primary interest of this transformation is to extend the benefits of AD to the TC themselves while preserving the performance capabilities of TC.

## Introduction

Automatic differentiation (AD) dramatically simplify writing a differentiable programming (DP) toolkit. AD delivers both high performance and high accuracy, which being extremely expressive, as it can be applied to any _program_. As such, AD belong to the realm of [compiler design](https://en.wikipedia.org/wiki/Compiler) rather than belonging to numerical analysis. AD comes in two modes: _forward AD_ and _reverse AD_ (see Ref 1). From a machine learning perspective, it's the _reverse AD_ mode which matters as the computational network is always differentiated with respect of the error criterion, which boils down to a single scalar.

Tensor Comprehensions (see Ref 2) represent an approach to represent an entire class of operations on _tensors_; all those operations having in common a polyhedral algebra making them suitable for intense low-level optimization by the compiler itself, typically when targeting a GPU (probably TPUs in the future). To illustrated the concept, let's start with a simple matrix-vector product, written with the _Facebook TC_ syntax (see Ref 2): 

    def mv(float(M,N) A, float(N) B) → (C) {
      C(i) +=! A(i,j) * B(j)
    }

The main point of the present document is to **show that a TC block can be AD into another TC block**. This exercise is of prime interest because the implementation of the DP toolkit:
*  **learner** with the AD that propagates down to the lowest logical level, removing the need to special-case tensor operations.
* **faster** assuming that a high-performance compiler for tensor comprehensions is already available. 

Formally, the function `mv` can seen as $\text{mv}: (A_{MN}, B_N) \to C_N$ using a generic notation where $A_{MN}$ refers to a tensor of dimensions $M$ and $N$. This notation extends canonically if more dimensions are present. 

For a given parameter tensor $A$ of a model being differentiated, let $\overline{A}$ be the _adjoint_ as defined in the AD literature (see Ref 1). As the differentiation happens only for a single target output variable - the loss function - there is only a single adjoint for every parameter of the model; thus, in practice, the $\overline{A}$ of interest has identical dimensions to $A$.

Under the TC context, the reverse AD transformation consists of constructing the _adjoint_ transformation  $\overline{\text{mv}}:(A_{MN}, B_N, (C_N, \overline{C}_N))\to(\overline{A}_{MN}, \overline{B}_N)$. As we will see in the following the parameter $C_N$ is not needed in this specific case - but it will be needed in more general situations.

Back to the matrix-vector product example given above, as we have $C = A * B$, applying by reverse AD, we get:

$$\overline{A}=\overline{C}\frac{\partial C}{\partial A} = \overline{C} * B$$

$$\overline{B}=\overline{C}\frac{\partial C}{\partial B} = \overline{C} * A$$

Proceeding back to the TC syntax and suffixing the adjoints by `x` for the sake of clarity, we get:

    def adj_mv(float(M,N) A, float(N) B, float(N) Cx → (Ax, Bx) {
      Ax(i, j) += Cx(i) * B(j)
      Bx(j) += Cx(j) * A(i, j)
    }
The input tensor `C` is omitted as it is not used.

More generally if we have a tensor comprehension $f$ as: 
$$f:(A,B,C) \to (D, E)$$
then applying the reverse AD gives 
$$\overline{f}: (A, B, C, (D, \overline{D}), (E, \overline{E}))\to(\overline{A}, \overline{B}, \overline{C})$$

An adjoint tensor is computed for every input tensor, and this adjoint tensor matches the dimension of its original counterpart.

## Transforming the sum

When the _sum_ aggregator is involved, the resulting reverse TC is direct because the sum is distributive with respective of the derivative:

$$y=f(x_1, \dots, x_n)=\sum_i g_i(x_i)$$

Let's introduce $v_i=g_i(x_i)$ and $v_{n+1}=\sum_{i=1}^n v_i$

Taking the reverse AD process, we have:

$$\overline{v}_{n+1}=\overline{y}=1$$

$$\overline{v}_i= \overline{v}_{n+1} \frac{\partial v_{n+1}}{\partial v_i}=\overline{v}_{n+1}=1$$

Let's consider the BLAS operation `sgemm`:

    def sgemm(float a, float b,
      float(N,M) A, float(M,Q) B) → (C) {
      C(i,j) = b # initialization
      C(i,j) += a * A(i,k) * B(k,j) # accumulation
    }

The reverse AD gives:

    def adj_sgemm(float a, float b,
      float(N,M) A, float(M,Q) B, float(N, Q) Cx → (ax, bx, Ax, Bx) {
      Ax(i,k) +=! Cx(i, j) * a * B(k, j)
      Bx(k,j) +=! Cx(i, j) * a * A(i, k)
      ax +=! Cx(i, j) * A(i,k) * B(k,j)
      bx = 1 
    }


## Transforming the max

The _max_ aggregator is somewhat more complex to analyze than the _sum_. Let's introduce the function $\text{argmax}: \mathbb{R}^n \to \mathbb{R}^n$ defined with:

$$\text{argmax}(x_1, \dots, x_n) = (1 \text{ if } x_i \text{ is the max else } 0)_i$$

$$y=f(x_1, \dots, x_n)=\max_i g_i(x_i) = (g_i(x_i))_i \circ \text{argmax} (g_i(x_i))_i$$

Where $\circ$ is the Hadamard product, the point-wise vector multiplication.

Let's introduce $v_i=g_i(x_i)$ and $v'_i=\text{argmax} (g_i(x_i))_i[i]$ and finally,
$$v_{n+1}=\sum_{i=1}^n v_i  v'_i$$

Taking the reverse AD process, we have:

$$\overline{v}_{n+1}=\overline{y} = 1$$

$$\overline{v}_i= \overline{v}_{n+1} \frac{\partial v_{n+1}}{\partial v_i}=\overline{v}_{n+1} v'_i = v'_i$$

$$\overline{v}'_i= \overline{v}_{n+1} \frac{\partial v_{n+1}}{\partial v'_i}=\overline{v}_{n+1} v_i = v_i$$

Let's consider a simple max-over-each-columns:

    def maxmv(float(M,N) A) → (B) {
      B(i) max=! A(i,j)
    }
 The adjoint is given by:
 
    def adj_maxmv(float(M,N) A, float(M) B, float(M) Bx → (Ax) {
      Ax(i, j1) max=! Bx(i) * A(i, j2) # beware 'j2' instead of 'j1'
    }
 
## Range inference friction

The _Facebook TC_ comes with a _range inference_ mechanism where the dimensions of the input tensors are specified, while the dimensions of the output tensors are inferred. This allows to concisely cope with situations where the output dimensions cannot trivially be inferred from the input ones. For example, let's considering the max pooling layer:

    def maxpool2x2(float(B,C,H,W) IN) → (OUT) {
      OUT(b,c,i,j) max=! IN(b,c, 2*i + kw, 2*j + kh)
        where kw in 0:2, kh in 0:2
    }

The adjoint transformation would give:

    def adj_maxpool2x2(
       float(B,C,H1,W1) IN, 
       float(B,C,H2,W2) OUTx) 
       → (INx) {
      INx(b,c, 2*i + kw1, 2*j + kh1) max=! 
        OUTx(b,c,i,j) * IN(b,c, 2*i + kw2, 2*j + kh2)
          where kw1 in 0:2, kh1 in 0:2, kw2 in 0:2, kh2 in 0:2
    }
However, as index algebra is authorized on the right side of the expressions, we rewrite those indices moving the logic from the left to the right:

    def adj_maxpool2x2(
       float(B,C,H1,W1) IN, 
       float(B,C,H2,W2) OUTx) 
       → (INx) {
      INx(b,c,i,j) max=! 
        OUTx(b,c, (i - kw1) / 2, (j - kh1) / 2) 
        * IN(b,c, i - kw1 + kw2, j - kw1 + kh2)
          where kw1 in 0:2, kh1 in 0:2, kw2 in 0:2, kh2 in 0:2
    }


## References

1. _Automatic differentiation in machine learning: a survey_. Atilim Gunes Baydin, Barak A. Pearlmutter, Alexey Andreyevich Radul, Jeffrey Mark Siskind. February 2018 [link](https://arxiv.org/pdf/1502.05767.pdf)
2. _Tensor Comprehensions: Framework-Agnostic High-Performance Machine Learning Abstractions_. Nicolas Vasilache, Oleksandr Zinenko, Theodoros Theodoridis, Priya Goyal, Zachary DeVito, William S. Moses, Sven Verdoolaege, Andrew Adams, Albert Cohen. February 2018 [link](https://arxiv.org/abs/1802.04730)
