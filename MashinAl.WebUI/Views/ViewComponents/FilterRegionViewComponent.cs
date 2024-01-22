using MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterRegionViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterRegionViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new RegionGetAllRequest());
            return View(response);
        }
    }
}
