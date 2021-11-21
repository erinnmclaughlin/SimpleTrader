using SimpleTrader.Domain.Results.StockPriceResults;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    internal class StockPriceService : IStockPriceService
    {
        public async Task<GetPriceResult> GetPrice(string symbol)
        {
            var uri = "quote-short/" + symbol;
            using var client = new FinancialModelingPrepHttpClient();
            var result = (await client.GetAsync<StockPriceResult[]>(uri)).SingleOrDefault();

            if (result is null)
                return GetPriceResult.InvalidSymbol(symbol);

            return GetPriceResult.Succeed(result.Price);
        }
    }
}
