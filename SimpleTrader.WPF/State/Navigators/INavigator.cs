using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
    internal interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ObservableCollection<NavigationItem> NavigationItems { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
