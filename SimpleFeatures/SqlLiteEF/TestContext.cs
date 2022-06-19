using Microsoft.EntityFrameworkCore;

namespace SqlLiteEF
{
    public class TestContext : DbContext
    {
        public string DbPath { get; }

        public TestContext()
        {
            DbPath = Path.Join(Directory.GetCurrentDirectory(), "dbtest.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Table1> Table1 { get; set; }
        public DbSet<Table2> Table2 { get; set; }
    }
}