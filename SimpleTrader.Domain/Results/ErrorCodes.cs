namespace SimpleTrader.Domain.Results
{
    public enum AccountError
    {
        InsufficientFunds,
        Unknown
    }

    public enum LoginError
    { 
        InvalidUsername,
        InvalidPassword,
        Unknown
    }

    public enum RegisterError
    { 
        PasswordsDoNotMatch,
        UsernameExists,
        EmailExists,
        Unknown
    }

    public enum StockError
    {
        InvalidSymbol,
        Unknown
    }
}
