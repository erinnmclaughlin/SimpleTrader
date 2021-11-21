using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Models
{
    internal class NavigationItem : ObservableObject
    {
        public string Title { get; }
        public ViewModelBase ViewModel { get; }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public NavigationItem(string title, ViewModelBase viewModel, bool isChecked)
        {
            Title = title;
            ViewModel = viewModel;
            IsChecked = isChecked;
        }
    }
}
