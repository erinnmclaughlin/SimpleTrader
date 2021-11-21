using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

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

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            var stockPrice = await _stockPriceService.GetPrice(symbol);
            var transactionPrice = stockPrice * shares;

            if (buyer.Balance < transactionPrice)
            {
                throw new InsufficientFundsException(buyer.Balance, transactionPrice);
            }

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
            return buyer;
        }
    }
}
