using Microsoft.AspNetCore.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Results.AuthenticationResults;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher<User> passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var account = await _accountService.GetByUsername(username);

            if (account is null || _passwordHasher.VerifyHashedPassword(account.AccountHolder, account.AccountHolder.PasswordHash, password) != PasswordVerificationResult.Success)
                return LoginResult.InvalidCredentials();

            return LoginResult.Succeed(account);
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return RegistrationResult.PasswordsDoNotMatch();

            if (await _accountService.GetByEmail(email) is not null)
                return RegistrationResult.EmailExists(email);

            if (await _accountService.GetByUsername(username) is not null)
                return RegistrationResult.UsernameExists(username);

            var user = new User
            {
                Email = email,
                Username = username
            };

            user.PasswordHash = GetHashedPassword(user, password);
            await _accountService.Create(new Account { AccountHolder = user });
            return RegistrationResult.Succeed();
        }

        private string GetHashedPassword(User user, string password) => _passwordHasher.HashPassword(user, password);
    }
}
