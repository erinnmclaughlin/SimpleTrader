using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
    internal class ReadDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public ReadDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity!;
        }
    }
}
