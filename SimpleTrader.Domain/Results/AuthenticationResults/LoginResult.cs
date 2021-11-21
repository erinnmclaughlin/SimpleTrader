using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Results.AuthenticationResults
{
    public class LoginResult : Result<Account>
    {
        public LoginError? ErrorCode { get; private set; }

        public static LoginResult Succeed(Account account) => Succeed<LoginResult>(account);

        public static LoginResult Fail(string? message = null, LoginError error = LoginError.Unknown)
        {
            var result = Fail<LoginResult>(message);
            result.ErrorCode = error;
            return result;
        }

        public static LoginResult InvalidCredentials()
            => Fail("Invalid credentials.", LoginError.InvalidCredentials);
    }
}
