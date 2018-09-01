using System;
using System.Runtime.CompilerServices;

namespace Adrien.Numerics.Reference
{
    /// <summary>
    /// Spans are not eligible yet to Linq expression trees:
    /// https://stackoverflow.com/questions/52112628/how-to-get-a-value-out-of-a-spant-with-linq-expression-trees
    /// This class is a work-around, wrapping all 'Span{T}' operations
    /// under static methods.
    /// </summary>
    public static class SpanMethods
    {
        public static string GetSpanItem => "InternalGetSpanItem";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InternalGetSpanItem<T>(Span<T> span, int index)
        {
            return span[index];
        }

        public static string SetDefaultSpanItem => "InternalSetDefaultSpanItem";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetDefaultSpanItem<T>(Span<T> span, int index)
        {
            span[index] = default;
        }

        public static string SetSpanItem => "InternalSetSpanItem";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] = value;
        }

        public static string SetAddSpanItem => "InternalSetAddSpanItem";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetAddSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] += value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetAddSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] += value;
        }

        public static string SetMaxSpanItem => "InternalSetMaxSpanItem";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetMaxSpanItemInt32(Span<int> span, int index, int value)
        {
            span[index] = span[index] > value ? span[index] : value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InternalSetMaxSpanItemSingle(Span<float> span, int index, float value)
        {
            span[index] = span[index] > value ? span[index] : value;
        }
    }
}