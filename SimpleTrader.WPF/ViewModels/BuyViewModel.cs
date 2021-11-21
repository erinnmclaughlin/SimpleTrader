using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    internal class BuyViewModel : ViewModelBase
    {
        public ICommand BuyStockCommand { get; }
        public ICommand SearchSymbolCommand { get; }

        public double TotalPrice => SharesToBuy * StockPrice;

        private int _sharesToBuy;
        public int SharesToBuy
        {
            get => _sharesToBuy;
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private string _searchResultSymbol = string.Empty;
        public string SearchResultSymbol
        {
            get => _searchResultSymbol;
            set
            {
                _searchResultSymbol = value;
                SharesToBuy = 0;
                OnPropertyChanged(nameof(SearchResultSymbol));
            }
        }

        private string? _symbol;
        public string? Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value?.ToUpper();
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private double _stockPrice;
        public double StockPrice
        {
            get => _stockPrice;
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
            }
        }

        public BuyViewModel(IBuyStockService buyStockService, IStockPriceService stockPriceService)
        {
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
        }

    }
}
