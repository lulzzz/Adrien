using System;

namespace Adrien.Core
{
    public enum BeamKind
    {
        SetShape,
        SetElementKind,
        PairElementKind,
        SetRank,
        InferRank,
        SetDimension,
        InferDimension
    }

    /// <summary>
    /// A constraint on the shape of a variable.
    /// </summary>
    /// <remarks>
    /// The geometric inference is the process used to identify
    /// the unique shape associated to each variable as a resolution
    /// of the system of constraints defined by the beams.
    /// </remarks>
    public class Beam
    {
        public BeamKind Kind { get; }

        public Variable Target { get; set; }

        public Variable Dependency { get; set; }

        public static Beam SetShape(Variable target, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static Beam SetElementKind(Variable target, ElementKind kind)
        {
            throw new NotImplementedException();
        }

        public static Beam PairElementKind(Variable target, Variable dependency)
        {
            throw new NotImplementedException();
        }

        public static Beam SetRank(Variable target, int rank)
        {
            throw new NotImplementedException();
        }

        public static Beam InferRank(Variable target, Variable dependency, Func<int, int> infer)
        {
            throw new NotImplementedException();
        }

        public static Beam SetDimension(Variable target, int dimIndex, int dimSize)
        {
            throw new NotImplementedException();
        }

        public static Beam SetDimension(Variable target, Variable dependency, int dimIndex, Func<int, int> infer)
        {
            throw new NotImplementedException();
        }
    }
}
