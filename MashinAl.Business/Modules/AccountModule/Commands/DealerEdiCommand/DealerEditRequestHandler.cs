using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Commands.DealerEdiCommand
{
    internal class DealerEditRequestHandler : IRequestHandler<DealerEditRequest>
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<MashinAlUser> userManager;
        private readonly IFileService fileService;

        public DealerEditRequestHandler(IIdentityService identityService, UserManager<MashinAlUser> userManager, IFileService fileService)
        {
            this.identityService = identityService;
            this.userManager = userManager;
            this.fileService = fileService;
        }
        public async Task Handle(DealerEditRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(identityService.GetPrincipalId().ToString());

            user.DealershipDescription = request.Description;
            user.DealershipName = request.DealerName;
            user.DealershipAddress = request.Address;
            user.ImagePath = fileService.ChangeFile(request.Image, user.ImagePath);

            await userManager.UpdateAsync(user);

        }
    }
}
