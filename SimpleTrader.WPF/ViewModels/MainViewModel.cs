using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
        }
    }
}
