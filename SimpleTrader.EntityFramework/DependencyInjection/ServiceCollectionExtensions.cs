using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services;

namespace SimpleTrader.EntityFramework.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services.AddSingleton<SimpleTraderDbContextFactory>();
        }

        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services.AddSingleton<IDataService<Account>, AccountDataService>();
        }
    }
}
