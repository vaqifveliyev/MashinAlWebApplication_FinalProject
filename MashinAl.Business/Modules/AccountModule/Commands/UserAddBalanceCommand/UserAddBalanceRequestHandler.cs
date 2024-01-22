using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Commands.UserAddBalanceCommand
{
    internal class UserAddBalanceRequestHandler : IRequestHandler<UserAddBalanceRequest>
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<MashinAlUser> userManager;

        public UserAddBalanceRequestHandler(IIdentityService identityService, UserManager<MashinAlUser> userManager)
        {
            this.identityService = identityService;
            this.userManager = userManager;
        }
        public async Task Handle(UserAddBalanceRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(identityService.GetPrincipalId().ToString());
            
            user.Balance = user.Balance + request.Amount;

            await userManager.UpdateAsync(user);
        }
    }
}
