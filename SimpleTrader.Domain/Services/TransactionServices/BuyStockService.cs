using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Results.TransactionResults;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    internal class BuyStockService : IBuyStockService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IStockPriceService _stockPriceService;

        public BuyStockService(IDataService<Account> accountService, IStockPriceService stockPriceService)
        {
            _accountService = accountService;
            _stockPriceService = stockPriceService;
        }

        public async Task<BuyStockResult> BuyStock(Account buyer, string symbol, int shares)
        {
            var result = await _stockPriceService.GetPrice(symbol);
            var stockPrice = result.Data;

            var transactionPrice = stockPrice * shares;

            if (buyer.Balance < transactionPrice)
                return BuyStockResult.InsufficientFunds();

            var transaction = new AssetTransaction
            {
                Account = buyer,
                Asset = new Asset { SharePrice = stockPrice, Symbol = symbol },
                IsPurchase = true,
                Shares = shares
            };

            buyer.AssetTransactions?.Add(transaction);
            buyer.Balance -= transactionPrice;

            await _accountService.Update(buyer.Id, buyer);
            return BuyStockResult.Succeed(buyer);
        }
    }
}
