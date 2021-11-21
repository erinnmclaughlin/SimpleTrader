using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    internal class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            var uri = "real-time-price/" + symbol;
            using var client = new FinancialModelingPrepHttpClient();
            var result = await client.GetAsync<StockPriceResult>(uri);

            if (result.Price == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return result.Price;
        }
    }
}
