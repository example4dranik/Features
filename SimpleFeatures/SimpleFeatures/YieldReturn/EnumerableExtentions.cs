namespace SimpleFeatures.YieldReturn
{
    public static class EnumerableExtentions
    {
        public static IEnumerable<IList<T>> SplitBy<T>(this T[] items, int batch)
        {
            if (items == null) yield break;
            if (batch <= 0) throw new ArgumentException("Value should be > 0", nameof(SplitBy));

            for (int i = 0; i < items.Length; i += batch)
            {
                yield return new ArraySegment<T>(items, i, Math.Min(batch, items.Length - i));
            }
        }
    }
}