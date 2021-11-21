using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNavigation(this IServiceCollection services)
        {
            return services.AddScoped<INavigator, Navigator>()
                .AddScoped<NavigationCollection>();
        }

        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            return services.AddScoped<MainViewModel>();
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            return services.AddScoped<HomeViewModel>()
                .AddScoped<MainViewModel>()
                .AddScoped<MajorIndexListingViewModel>()
                .AddScoped<PortfolioViewModel>();
        }
    }
}
