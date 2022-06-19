namespace SimpleFeatures.JoinMultiKey
{
    public class JoinMultiKey : ISolution
    {
        public void Execute()
        {
            var tableA = new List<Row>
            {
                new Row(1, "A", "a1"),
                new Row(2, "A", "a2"),
                new Row(3, "A", "a3"),
                new Row(4, "B", "b1"),
                new Row(5, "C", "c1")
            };

            var tableB = new List<Row>
            {
                new Row(1, "A", "a1"),
                new Row(2, "B", "b1")
            };

            Console.WriteLine("Input key");
            string key = Console.ReadLine();

            var res = tableA.Where(w => w.Field1 == key)
                .Join(
                tableB.AsEnumerable(),
                ta => new
                {
                    k1 = ta.Field1,
                    k2 = ta.Field2
                },
                tb => new
                {
                    k1 = tb.Field1,
                    k2 = tb.Field2
                },
                (ta, tb) => new
                {
                    ida = ta.Id,
                    f1a = ta.Field1,
                    f2a = ta.Field2,
                    idb = tb.Id,
                    f1b = tb.Field1,
                    f2b = tb.Field2
                }).ToList();

            foreach (var r in res)
            {
                Console.WriteLine($"{r.ida}-{r.idb} {r.f1a}-{r.f1b} {r.f2a}-{r.f2b}{Environment.NewLine}");
            }
        }
    }
}