namespace SimpleTrader.WPF.ViewModels
{
    internal class HomeViewModel : ViewModelBase 
    {
        private bool _isLoaded;

        public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public void Load()
        {
            if (_isLoaded)
                return;

            MajorIndexListingViewModel.LoadMajorIndices();
            _isLoaded = true;
        }
    }
}
