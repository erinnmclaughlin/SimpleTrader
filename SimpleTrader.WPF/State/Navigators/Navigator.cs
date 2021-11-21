using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
    internal class Navigator : ObservableObject, INavigator
    {
        public ObservableCollection<NavigationItem> NavigationItems { get; set; }

        private ViewModelBase _currentViewModel = null!;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

        public Navigator(NavigationCollection navigationCollection)
        {
            NavigationItems = navigationCollection;
            CurrentViewModel = NavigationItems.Single(x => x.IsChecked).ViewModel;
        }
    }
}
