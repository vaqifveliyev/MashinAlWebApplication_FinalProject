using MashinAl.Business.Modules.AccountModule.Queries.GetDealerProfileQuery;
using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class DealerProfileViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public DealerProfileViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new GetDealerProfileRequest());
            return View(response);
        }
    }
}
