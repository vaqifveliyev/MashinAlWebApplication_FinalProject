using MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class DealerCarWaitingViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public DealerCarWaitingViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new CarGetAllByUserRequest());
            return View(response);
        }
    }
}
