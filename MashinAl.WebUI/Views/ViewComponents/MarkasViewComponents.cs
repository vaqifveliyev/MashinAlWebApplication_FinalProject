using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class MarkasViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public MarkasViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new MarkaGetAllRequest());
            return View(response);
        }
    }
}
