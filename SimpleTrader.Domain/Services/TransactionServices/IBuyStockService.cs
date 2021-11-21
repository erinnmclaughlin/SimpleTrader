using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Results.TransactionResults;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task<BuyStockResult> BuyStock(Account buyer, string symbol, int shares);
    }
}
