using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class LicensePlatesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public LicensePlatesViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new PlateGetAllRequest());
            var filteredResponse = response.Where(m => m.IsAccepted != false);
            return View(filteredResponse);
        }
    }
}
