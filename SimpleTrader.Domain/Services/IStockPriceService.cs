using SimpleTrader.Domain.Results.StockPriceResults;

namespace SimpleTrader.Domain.Services
{
    public interface IStockPriceService
    {
        Task<GetPriceResult> GetPrice(string symbol);
    }
}
