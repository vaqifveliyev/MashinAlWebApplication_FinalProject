using FluentValidation;
using MashinAl.Infastructure.Entities.Membership;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Commands.SigninCommand
{
    public class SigninRequestValidator : AbstractValidator<SigninRequest>
    {
        public SigninRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("E-mail ünvanı boş ola bilməz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə boş ola bilməz.");
        }
    }
}
