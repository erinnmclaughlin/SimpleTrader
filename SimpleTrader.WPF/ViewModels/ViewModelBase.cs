using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.ViewModels
{

    internal delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    internal class ViewModelBase : ObservableObject
    {
    }
}
