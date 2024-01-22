using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class BoostedCarsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public BoostedCarsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new CarGetAllRequest());
            return View(response);
        }
    }
}
