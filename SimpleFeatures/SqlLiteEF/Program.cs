using SqlLiteEF;

using (TestContext context = new TestContext())
{
    ClearTables(context);

    for (int i = 1; i <= 5; i++)
    {
        var newRow = new Table1
        {
            F1 = i,
            F2 = i.ToString(),
            F3 = BitConverter.GetBytes(DateTime.Now.Ticks)
        };
        context.Table1.Add(newRow);
    }

    context.SaveChanges();

    Console.WriteLine($"{nameof(Table1)}");
    context.Table1.Select(s => new
    {
        F1 = s.F1,
        F2 = s.F2,
        F3 = s.F3
    }).ToList()
    .ForEach(r => Console.WriteLine($"{r.F1}, {r.F2}, {r.F3}"));

    Console.WriteLine($"{nameof(Table2)}");
    context.Table2.Select(s => new
    {
        F1 = s.F1,
        F2 = s.F2,
        F3 = s.F3
    }).ToList()
    .ForEach(r => Console.WriteLine($"{r.F1}, {r.F2}, {r.F3}"));
}

Console.ReadLine();

static void ClearTables(TestContext context)
{
    var allTable1Rows = context.Table1.ToList();
    context.Table1.RemoveRange(allTable1Rows);

    var allTable2Rows = context.Table2.ToList();
    context.Table2.RemoveRange(allTable2Rows);

    context.SaveChanges();
}