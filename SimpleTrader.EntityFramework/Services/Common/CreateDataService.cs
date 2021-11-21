using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
    internal class CreateDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public CreateDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
