using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Results.TransactionResults
{
    public class BuyStockResult : Result<Account>
    {
        public AccountError? ErrorCode { get; private set; }

        public static BuyStockResult Succeed(Account account) => Succeed<BuyStockResult>(account);

        public static BuyStockResult Fail(AccountError error, string? message = null)
        {
            var result = Fail<BuyStockResult>(message);
            result.ErrorCode = error;
            return result;
        }

        public static BuyStockResult InsufficientFunds()
            => Fail(AccountError.InsufficientFunds, "Insufficient funds.");
    }
}
