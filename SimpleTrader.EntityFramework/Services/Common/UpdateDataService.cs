using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
    internal class UpdateDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public UpdateDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
