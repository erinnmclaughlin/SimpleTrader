using SimpleTrader.WPF.State.Navigators;
using System;
using System.Linq;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    internal class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;

        public event EventHandler? CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is string title)
            {
                foreach (var item in _navigator.NavigationItems)
                    item.IsChecked = item.Title == title;

                _navigator.CurrentViewModel = _navigator.NavigationItems.Single(x => x.Title == title).ViewModel;
            }
        }
    }
}
