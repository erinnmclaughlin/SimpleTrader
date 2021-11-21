namespace SimpleTrader.WPF.ViewModels
{
    internal class HomeViewModel : ViewModelBase 
    {
        public MajorIndexListingViewModel MajorIndexViewModel { get; set; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexViewModel)
        {
            MajorIndexViewModel = majorIndexViewModel;
        }
    }
}
