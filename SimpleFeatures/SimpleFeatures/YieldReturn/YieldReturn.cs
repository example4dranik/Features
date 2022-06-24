namespace SimpleFeatures.YieldReturn
{
    public class YieldReturn : ISolution
    {
        public void Execute()
        {
            var collection = new List<Item>() { new Item("First"), new Item("Second"), new Item("Third"), new Item("Fourth"), new Item("Fifth"), new Item("Sixth"), new Item("Seventh") };

            foreach (var batch in SplitList(collection, 2))
            {
                batch.ForEach(r => Console.Write($" {r.Value} "));
                Console.WriteLine();
            }

            var array = collection.ToArray();
            foreach (var batch in array.SplitBy(4))
            {
                foreach (var it in batch)
                {
                    Console.Write($" {it.Value} ");
                }
                Console.WriteLine();
            }

            var num = new Numerator();
            foreach (var e in num.GetInt())
            {
                Console.WriteLine($"={e}");
            }

            foreach (var e in num.GetInt(true))
            {
                Console.WriteLine($"={e}");
            }
        }

        internal IEnumerable<List<T>> SplitList<T>(List<T> items, int size)
        {
            for (int i = 0; i < items.Count; i += size)
            {
                yield return items.GetRange(i, Math.Min(size, items.Count - i));
            }
        }
    }
}