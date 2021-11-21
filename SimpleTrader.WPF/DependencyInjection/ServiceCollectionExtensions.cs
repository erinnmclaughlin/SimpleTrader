using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System.Linq;
using System.Reflection;

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
            var viewModels = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(ViewModelBase));

            foreach (var viewModel in viewModels)
                services.AddScoped(viewModel);

            return services;
        }
    }
}
