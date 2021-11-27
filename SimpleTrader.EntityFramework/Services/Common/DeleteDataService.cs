using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
    internal class DeleteDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public DeleteDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Delete(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.FindAsync<T>(id);

            if (entity is null)
                return false;

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
