namespace SimpleTrader.Domain.Results
{
    public abstract class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        protected static TResult Succeed<TResult>(string? message = null) where TResult : Result, new()
        {
            return new TResult { Success = true, Message = message };
        }

        protected static TResult Fail<TResult>(string? message = null) where TResult: Result, new()
        {
            return new TResult { Message = message };
        }
    }

    public abstract class Result<T> : Result
    {
        public T? Data { get; set; }

        protected static TResult Succeed<TResult>(T? data, string? message = null) where TResult : Result<T>, new()
        {
            return new TResult { Data = data, Success = true, Message = message };
        }

        protected static new TResult Fail<TResult>(string? message = null) where TResult : Result<T>, new()
        {
            return new TResult { Message = message };
        }
    }
}
