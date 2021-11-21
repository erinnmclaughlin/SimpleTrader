using SimpleTrader.Domain.Results.AuthenticationResults;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<LoginResult> Login(string username, string password);
    }
}
