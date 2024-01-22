using MediatR;
using Microsoft.AspNetCore.Http;

namespace MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand
{
    public class RegisterRequest : IRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}
