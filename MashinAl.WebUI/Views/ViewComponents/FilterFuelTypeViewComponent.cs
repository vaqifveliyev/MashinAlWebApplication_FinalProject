using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterFuelTypeViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterFuelTypeViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new FuelTypeGetAllRequest());
            return View(response);
        }
    }
}
