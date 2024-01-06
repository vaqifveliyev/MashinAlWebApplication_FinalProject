using MediatR;
using System.Security.Claims;

namespace MashinAl.Business.Modules.AccountModule.Commands.BindClaimsCommand
{
    public class BindClaimsRequest : IRequest
    {
        public ClaimsIdentity Identity { get; set; }
    }
}
