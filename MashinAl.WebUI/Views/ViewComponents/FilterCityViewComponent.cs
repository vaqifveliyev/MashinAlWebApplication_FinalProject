using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterCityViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterCityViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new CityGetAllRequest());
            return View(response);
        }
    }
}
