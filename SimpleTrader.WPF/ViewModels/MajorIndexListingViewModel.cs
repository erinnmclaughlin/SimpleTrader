using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    internal class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;

        private MajorIndex? _dowJones;
        public MajorIndex? DowJones 
        { 
            get => _dowJones;
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex? _nasdaq;
        public MajorIndex? Nasdaq
        {
            get => _nasdaq;
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex? _sp500;
        public MajorIndex? SP500
        {
            get => _sp500;
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public void LoadMajorIndices()
        {
            if (DowJones is null)
            {
                _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
                {
                    if (task.Exception is null)
                    {
                        DowJones = task.Result;
                    }
                });
            }
            
            if (Nasdaq is null)
            {
                _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
                {
                    if (task.Exception is null)
                    {
                        Nasdaq = task.Result;
                    }
                });
            }

            if (SP500 is null)
            {
                _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
                {
                    if (task.Exception is null)
                    {
                        SP500 = task.Result;
                    }
                });
            }
        }
    }
}
