using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    internal class AccountDataService : IAccountService
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

        public async Task<bool> Delete(Guid id)
        {
            return await _deleteService.Delete(id);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return await GetDefaultQuery(context).ToListAsync();
        }

        public async Task<Account?> GetById(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await GetDefaultQuery(context).FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<Account?> GetByEmail(string email)
        {
            using var context = _contextFactory.CreateDbContext();
            var account = await GetDefaultQuery(context).FirstOrDefaultAsync(x => x.AccountHolder.Email == email);
            return account;
        }

        public async Task<Account?> GetByUsername(string username)
        {
            using var context = _contextFactory.CreateDbContext();
            var account = await GetDefaultQuery(context).FirstOrDefaultAsync(x => x.AccountHolder.Username == username);
            return account;
        }

        public async Task<Account> Update(Guid id, Account entity)
        {
            return await _updateService.Update(id, entity);
        }

        private static IQueryable<Account> GetDefaultQuery(SimpleTraderDbContext context) =>
            context.Accounts.Include(x => x.AccountHolder).Include(x => x.AssetTransactions);
    }
}
