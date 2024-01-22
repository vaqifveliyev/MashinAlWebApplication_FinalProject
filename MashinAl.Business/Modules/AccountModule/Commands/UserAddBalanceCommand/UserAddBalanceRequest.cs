using MediatR;

namespace MashinAl.Business.Modules.AccountModule.Commands.UserAddBalanceCommand
{
    public class UserAddBalanceRequest : IRequest
    {
        public int Amount { get; set; }
    }
}
