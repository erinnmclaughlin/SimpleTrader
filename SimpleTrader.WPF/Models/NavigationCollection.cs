using SimpleTrader.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleTrader.WPF.Models
{
    internal class NavigationCollection : ObservableCollection<NavigationItem>
    {
        public NavigationCollection(HomeViewModel home, PortfolioViewModel portfolio)
        {
            Add(new NavigationItem("Home", home));
            Add(new NavigationItem("Portfolio", portfolio));
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
