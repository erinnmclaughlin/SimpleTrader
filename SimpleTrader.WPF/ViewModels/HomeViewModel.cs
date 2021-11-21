namespace SimpleTrader.WPF.ViewModels
{
    internal class HomeViewModel : ViewModelBase 
    {
        public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public void Load()
        {
            MajorIndexListingViewModel.LoadMajorIndices();
        }
    }
}
