using MashinAl.Business.Modules.AccountModule.Commands.UserAddBalanceCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class UserAddBalanceViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public UserAddBalanceViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await mediator.Send(new UserAddBalanceRequest());
            return View();
        }
    }
}
