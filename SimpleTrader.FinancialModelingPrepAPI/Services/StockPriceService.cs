using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    internal class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            var uri = "quote-short/" + symbol;
            using var client = new FinancialModelingPrepHttpClient();
            var result = (await client.GetAsync<StockPriceResult[]>(uri)).SingleOrDefault();

            if (result is null)
                throw new InvalidSymbolException(symbol);

            return result.Price;
        }
    }
}
