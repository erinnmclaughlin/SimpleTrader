using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework
{
    internal class SimpleTraderDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<AssetTransaction> AssetTransactions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public SimpleTraderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AssetTransaction>().OwnsOne(x => x.Asset);
        }
    }
}
