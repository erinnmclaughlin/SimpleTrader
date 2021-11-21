using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionServices;

namespace SimpleTrader.Domain.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            return services.AddScoped<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddSingleton<IBuyStockService, BuyStockService>();
        }
    }
}
