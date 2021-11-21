using SimpleTrader.WPF.ViewModels;
using System.Collections.ObjectModel;

namespace SimpleTrader.WPF.Models
{
    internal class NavigationCollection : ObservableCollection<NavigationItem>
    {
        public NavigationCollection(HomeViewModel home, PortfolioViewModel portfolio)
        {
            Add(new NavigationItem("Home", home, true));
            Add(new NavigationItem("Portfolio", portfolio, false));
        }
    }
}
