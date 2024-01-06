using MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class SupplyViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public SupplyViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new SupplyGetAllRequest());
            return View(response);
        }
    }
}
