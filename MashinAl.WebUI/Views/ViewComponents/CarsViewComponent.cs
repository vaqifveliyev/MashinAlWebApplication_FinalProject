using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class CarsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public CarsViewComponent(IMediator mediator)
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
