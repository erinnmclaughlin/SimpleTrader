using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
    internal class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[]? args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDb;Trusted_Connection=True");

            return new SimpleTraderDbContext(optionsBuilder.Options);
        }
    }
}
