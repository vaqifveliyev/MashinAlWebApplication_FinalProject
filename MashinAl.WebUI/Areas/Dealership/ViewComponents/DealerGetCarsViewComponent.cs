using MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class DealerGetCarsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public DealerGetCarsViewComponent(IMediator mediator)
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
