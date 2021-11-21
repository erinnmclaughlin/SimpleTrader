namespace SimpleTrader.Domain.Results.AuthenticationResults
{
    public class RegistrationResult : Result
    {
        public RegisterError? ErrorCode { get; private set; }

        public static RegistrationResult Succeed() => Succeed<RegistrationResult>();

        public static RegistrationResult Fail(string? message = null, RegisterError error = RegisterError.Unknown)
        {
            var result = Fail<RegistrationResult>(message);
            result.ErrorCode = error;
            return result;
        }

        public static RegistrationResult PasswordsDoNotMatch() 
            => Fail("Passwords do not match.", RegisterError.PasswordsDoNotMatch);

        public static RegistrationResult UsernameExists(string username) 
            => Fail($"User with username {username} already exists.", RegisterError.UsernameExists);

        public static RegistrationResult EmailExists(string email) =>
            Fail($"User with email {email} already exists.", RegisterError.EmailExists);
    }
}
