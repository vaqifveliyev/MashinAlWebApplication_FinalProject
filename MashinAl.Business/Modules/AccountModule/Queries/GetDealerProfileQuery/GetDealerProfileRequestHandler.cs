using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Queries.GetDealerProfileQuery
{
    internal class GetDealerProfileRequestHandler : IRequestHandler<GetDealerProfileRequest, GetDealerProfileDto>
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<MashinAlUser> userManager;

        public GetDealerProfileRequestHandler(IIdentityService identityService, UserManager<MashinAlUser> userManager)
        {
            this.identityService = identityService;
            this.userManager = userManager;
        }
        public async Task<GetDealerProfileDto> Handle(GetDealerProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(identityService.GetPrincipalId().ToString());

            var profile = new GetDealerProfileDto
            {
                Id = user.Id,
                Balance = user.Balance,
                DealerNumber = user.DealershipNumber,
                ImagePath = user.ImagePath,
                Address = user.DealershipAddress,
                Description = user.DealershipDescription,
                DealerName = user.DealershipName,
            };

            return profile;
        }
    }
}
