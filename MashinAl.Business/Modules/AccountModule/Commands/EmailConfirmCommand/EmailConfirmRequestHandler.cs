using MashinAl.Infastructure.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.AccountModule.Commands.EmailConfirmCommand
{
    internal class EmailConfirmRequestHandler : IRequestHandler<EmailConfirmRequest>
    {
        private readonly UserManager<MashinAlUser> userManager;

        public EmailConfirmRequestHandler(UserManager<MashinAlUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task Handle(EmailConfirmRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            await userManager.ConfirmEmailAsync(user, request.Token);
        }
    }
}
