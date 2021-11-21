using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.DependencyInjection;
using SimpleTrader.EntityFramework.DependencyInjection;
using SimpleTrader.FinancialModelingPrepAPI.DependencyInjection;
using SimpleTrader.WPF.DependencyInjection;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();

            new MainWindow { DataContext = serviceProvider.GetRequiredService<MainViewModel>() }.Show();
            base.OnStartup(e);
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddDatabase()
                .AddDataServices()
                .AddDomainServices()
                .AddFinancialModelingPrepAPI()
                .AddNavigation()
                .AddViews()
                .AddViewModels()
                .BuildServiceProvider();
        }
    }
}
