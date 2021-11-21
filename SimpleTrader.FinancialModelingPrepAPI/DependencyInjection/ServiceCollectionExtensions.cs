using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFinancialModelingPrepAPI(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMajorIndexService, MajorIndexService>()
                .AddSingleton<IStockPriceService, StockPriceService>();
        }
    }
}
