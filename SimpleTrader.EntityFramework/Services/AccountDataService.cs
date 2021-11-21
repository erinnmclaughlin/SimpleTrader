using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    internal class AccountDataService : IDataService<Account>
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly CreateDataService<Account> _createService;
        private readonly UpdateDataService<Account> _updateService;
        private readonly DeleteDataService<Account> _deleteService;

        public AccountDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            _createService = new CreateDataService<Account>(contextFactory);
            _updateService = new UpdateDataService<Account>(contextFactory);
            _deleteService = new DeleteDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _createService.Create(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _deleteService.Delete(id);
        }

        public virtual async Task<IEnumerable<Account>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Accounts.Include(x => x.AssetTransactions).ToListAsync();
        }

        public virtual async Task<Account> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Accounts.Include(x => x.AssetTransactions).FirstOrDefaultAsync(x => x.Id == id);
            return entity!;
        }

        public virtual async Task<Account> Update(int id, Account entity)
        {
            return await _updateService.Update(id, entity);
        }
    }
}
