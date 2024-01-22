using MashinAl.Infastructure.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Queries.DealerGetByIdQuery
{
    internal class DealerGetByIdRequestHandler : IRequestHandler<DealerGetByIdRequest, DealerGetByIdDto>
    {
        private readonly UserManager<MashinAlUser> userManager;

        public DealerGetByIdRequestHandler(UserManager<MashinAlUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<DealerGetByIdDto> Handle(DealerGetByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());

            var data = new DealerGetByIdDto
            {
                UserId = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DealershipName = user.DealershipName,
                DealershipAddress = user.DealershipAddress,
                DealershipNumber = user.DealershipNumber,
                DealershipDescription = user.DealershipDescription,
                WorkingHours = user.WorkingHours,
                ImagePath = user.ImagePath
            };

            return data;
        }
    }
}
