using System.ComponentModel.DataAnnotations;

namespace MashinAl.Business.Modules.AccountModule.Commands.SigninCommand
{
    public class UserNotFoundException : ValidationException
    {
        public UserNotFoundException(string userName) : base($"{userName} - belə bir istifadəçi tapılmadı!")
        {
        }
    }

    public class InvalidCredentialsException : ValidationException
    {
        public InvalidCredentialsException() : base("Email, Mobil nömrə və ya şifrə səhvdir!")
        {
        }
    }

    public class EmailNotVerifiedException : ValidationException
    {
        public EmailNotVerifiedException(string userName) : base($"{userName} - hesab aktiv edilməyib!")
        {
        }
    }
}
