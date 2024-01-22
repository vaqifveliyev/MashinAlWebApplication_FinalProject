using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class PlateWaitingViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public PlateWaitingViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new PlateGetAllRequest());
            return View(response);
        }
    }
}
