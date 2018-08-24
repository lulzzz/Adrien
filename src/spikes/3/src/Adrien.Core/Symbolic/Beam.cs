using System;
using System.Collections.Generic;

namespace Adrien.Core.Symbolic
{
    public enum BeamKind
    {
        FixElementKind,
        PairElementKind,
        FixRank,
        InferRank,
        FixDimension,
        InferDimension
    }

    /// <summary>A constraint on the shape of a symbol.</summary>
    public class Beam
    {
        public BeamKind Kind { get; }

        public Symbol Target { get; set; }

        public Symbol Dependency { get; set; }

        public static Beam CreateFixElementKind(Symbol target, ElementKind kind)
        {
            throw new NotImplementedException();
        }

        public static Beam CreatePairElementKind(Symbol target, Symbol dependency)
        {
            throw new NotImplementedException();
        }

        public static Beam CreateFixedRank(Symbol target, int rank)
        {
            throw new NotImplementedException();
        }

        public static Beam CreateInferRank(Symbol target, Symbol dependency, Func<int, int> infer)
        {
            throw new NotImplementedException();
        }

        public static Beam CreateFixDimension(Symbol target, int dimIndex, int dimSize)
        {
            throw new NotImplementedException();
        }

        public static Beam CreateInferDimension(Symbol target, Symbol dependency, int dimIndex, Func<int, int> infer)
        {
            throw new NotImplementedException();
        }
    }
}
