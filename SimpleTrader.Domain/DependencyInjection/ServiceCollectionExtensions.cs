using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Services.TransactionServices;

namespace SimpleTrader.Domain.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddSingleton<IBuyStockService, BuyStockService>();
        }
    }
}
