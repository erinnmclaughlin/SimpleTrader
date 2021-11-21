namespace SimpleTrader.Domain.Results.StockPriceResults
{
    public class GetPriceResult : Result<double>
    {
        public StockError? ErrorCode { get; private set; }

        public static GetPriceResult Succeed(double price) => Succeed<GetPriceResult>(price);

        public static GetPriceResult Fail(StockError errorCode, string? message)
        {
            var result = Fail<GetPriceResult>(message);
            result.ErrorCode = errorCode;
            return result;
        }

        public static GetPriceResult InvalidSymbol(string symbol) => Fail(StockError.InvalidSymbol, $"Symbol {symbol} is invalid.");
    }
}
