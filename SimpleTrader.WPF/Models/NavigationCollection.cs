using SimpleTrader.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleTrader.WPF.Models
{
    internal class NavigationCollection : ObservableCollection<NavigationItem>
    {
        public NavigationCollection(HomeViewModel home, PortfolioViewModel portfolio, BuyViewModel buy)
        {
            Add(new NavigationItem("Home", home));
            Add(new NavigationItem("Portfolio", portfolio));
            Add(new NavigationItem("Buy", buy));
        }

        public void SelectViewModel(string title)
        {
            foreach (var item in this)
            {
                item.IsChecked = item.Title == title;
            }

            LoadSelectedViewModel();
        }

        public void LoadSelectedViewModel()
        {
            if (SelectedViewModel is HomeViewModel homeViewModel)
                homeViewModel.Load();
        }

        public ViewModelBase? SelectedViewModel => this.SingleOrDefault(x => x.IsChecked)?.ViewModel;
    }
}
