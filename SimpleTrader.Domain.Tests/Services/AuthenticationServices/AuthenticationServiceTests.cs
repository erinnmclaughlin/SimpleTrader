using Microsoft.AspNetCore.Identity;
using Moq;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Results;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System.Threading.Tasks;
using Xunit;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    public class AuthenticationServiceTests
    {
        private readonly Mock<IAccountService> _mockAccountService = new();
        private readonly Mock<IPasswordHasher<User>> _mockPasswordHasher = new();

        private AuthenticationService? _authenticationService;

        [Fact]
        public async Task Login_ValidUsernamdAndPassword_ReturnsCorrectAccount()
        {
            // Arrange
            string username = "testuser";
            _mockAccountService.Setup(x => x.GetByUsername(username)).ReturnsAsync(new Account { AccountHolder = new() { Username = username }});
            _mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Login(username, "");

            // Assert
            Assert.True(result.Success);
            Assert.Equal(username, result.Data?.AccountHolder.Username);
        }

        [Fact]
        public async Task Login_InvalidUsername_ReturnsInvalidCredentials()
        {
            // Arrange
            _mockAccountService.Setup(x => x.GetByUsername(It.IsAny<string>())).ReturnsAsync((Account?)null);
            _mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Login("", "");

            // Assert
            Assert.Null(result.Data);
            Assert.False(result.Success);
            Assert.Equal(LoginError.InvalidCredentials, result.ErrorCode);            
        }

        [Fact]
        public async Task Register_ValidInput_ReturnsSuccess()
        {
            // Arrange
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Register("", "", "", "");

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Register_PasswordsDoNotMatch_ReturnsPasswordsDoNotMatch()
        {
            // Arrange
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Register("", "", "thing1", "thing2");

            // Assert
            Assert.False(result.Success);
            Assert.Equal(RegisterError.PasswordsDoNotMatch, result.ErrorCode);
        }

        [Fact]
        public async Task Register_ExistingEmail_ReturnsEmailExists()
        {
            // Arrange
            _mockAccountService.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(new Account());
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Register("", "", "", "");

            // Assert
            Assert.False(result.Success);
            Assert.Equal(RegisterError.EmailExists, result.ErrorCode);
        }

        [Fact]
        public async Task Register_ExistingUsername_ReturnsUsernameExists()
        {
            // Arrange
            _mockAccountService.Setup(x => x.GetByUsername(It.IsAny<string>())).ReturnsAsync(new Account());
            CreateAuthenticationService();

            // Act
            var result = await _authenticationService!.Register("", "", "", "");

            // Assert
            Assert.False(result.Success);
            Assert.Equal(RegisterError.UsernameExists, result.ErrorCode);
        }

        private void CreateAuthenticationService() => _authenticationService = new(_mockAccountService.Object, _mockPasswordHasher.Object);
    }
}
