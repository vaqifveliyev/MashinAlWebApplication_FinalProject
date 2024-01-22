using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Queries.GetAccountBalanceQuery
{
    internal class GetUserBalanceRequestHandler : IRequestHandler<GetUserBalanceRequest, GetUserBalanceDto>
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<MashinAlUser> userManager;

        public GetUserBalanceRequestHandler(IIdentityService identityService, UserManager<MashinAlUser> userManager)
        {
            this.identityService = identityService;
            this.userManager = userManager;
        }
        public async Task<GetUserBalanceDto> Handle(GetUserBalanceRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(identityService.GetPrincipalId().ToString());

            var balance = new GetUserBalanceDto
            {
                Id = user.Id,
                Balance = user.Balance,
            };

            return balance;
        }
    }
}
