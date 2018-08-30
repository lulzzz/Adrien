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
    /// A constraint on the shape of a symbol or of a variable.
    /// </summary>
    /// <remarks>
    /// The geometric inference is the process used to identify
    /// the unique shape associated to each variable as a resolution
    /// of the system of constraints defined by the beams.
    /// </remarks>
    public class Beam<T> where T : class
    {
        public BeamKind Kind { get; }

        public T Target { get; }

        public T Dependency { get; }

        public Shape Shape { get; }

        public ElementKind ElementKind { get; }

        public int Rank { get; }

        public (int,int) Dimension { get; }

        public Func<int,int> InferRank { get; }

        public int TargetDimensionIndex { get; }

        public int DependencyDimensionIndex { get; }

        public Func<int, int> InferDimension { get; }

        public Beam(T target, Shape shape)
        {
            Kind = BeamKind.SetShape;
            Shape = shape;
        }

        public Beam(T target, ElementKind kind)
        {
            Kind = BeamKind.SetElementKind;
            ElementKind = kind;
        }

        public Beam(T target, int rank)
        {
            Kind = BeamKind.SetRank;
            Rank = rank;
        }

        public Beam(T target, int dimIndex, int dimSize)
        {
            Kind = BeamKind.SetDimension;
            Dimension = (dimIndex, dimSize);
        }

        public Beam(T target, T dependency)
        {
            Kind = BeamKind.PairElementKind;
            Target = target;
            Dependency = dependency;
        }

        public Beam(T target, T dependency, Func<int, int> inferRank)
        {
            Kind = BeamKind.InferRank;
            Target = target;
            Dependency = dependency;
            InferRank = inferRank;
        }

        public Beam(T target, T dependency, 
            int targetDimensionIndex, int dependencyDimensionIndex, Func<int, int> inferDimension)
        {
            Kind = BeamKind.InferDimension;
            Target = target;
            Dependency = dependency;
            TargetDimensionIndex = targetDimensionIndex;
            DependencyDimensionIndex = dependencyDimensionIndex;
            InferDimension = inferDimension;
        }
    }
}
