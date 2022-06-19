namespace SimpleFeatures.JoinMultiKey
{
    public class JoinMultiKey : ISolution
    {
        public void Execute()
        {
            List<Row> tableA = new List<Row>();
            tableA.Add(new Row(1, "A", "a1"));
            tableA.Add(new Row(2, "A", "a2"));
            tableA.Add(new Row(3, "A", "a3"));
            tableA.Add(new Row(4, "B", "b1"));
            tableA.Add(new Row(5, "C", "c1"));

            List<Row> tableB = new List<Row>();
            tableB.Add(new Row(1, "A", "a1"));
            tableB.Add(new Row(2, "B", "b1"));

            Console.WriteLine("Input key");
            string key = Console.ReadLine();

            var res = tableA.Where(w => w.field1 == key)
                .Join(
                tableB.AsEnumerable(),
                ta => new
                {
                    k1 = ta.field1,
                    k2 = ta.field2
                },
                tb => new
                {
                    k1 = tb.field1,
                    k2 = tb.field2
                },
                (ta, tb) => new
                {
                    ida = ta.id,
                    f1a = ta.field1,
                    f2a = ta.field2,
                    idb = tb.id,
                    f1b = tb.field1,
                    f2b = tb.field2
                }).ToList();

            foreach (var r in res)
            {
                Console.WriteLine($"{r.ida}-{r.idb} {r.f1a}-{r.f1b} {r.f2a}-{r.f2b}{Environment.NewLine}");
            }
        }
    }
}