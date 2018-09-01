using System;
using Adrien.Ast;
using Adrien.Numerics;

namespace Adrien.Optimization
{
    /// <remarks>
    /// Adam: A Method for Stochastic Optimization, Diederik P. Kingma, Jimmy Ba, 2014
    /// See https://arxiv.org/abs/1412.6980
    /// </remarks>
    public class AdamOptimizer
    {
        public AdamOptimizer(ITileCompiler compiler, ITensorAllocator allocator)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// The optimization relies on two graph-to-graph transformations.
        /// First, the automatic differentiation which provides parameter
        /// updates to be obtained from every single input. Second, the
        /// minibatching which provides a more granular and more efficient
        /// way to compute the parameter updates.
        /// </remarks>
        public Flow Optimize(Graph graph, IDataBinder dataSource)
        {

            throw new NotImplementedException();
        }
    }
}
