using MediatR;

namespace MashinAl.Business.Modules.AccountModule.Commands.SigninCommand
{
    public class SigninRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
