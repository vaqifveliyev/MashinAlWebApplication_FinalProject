using MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterColorViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterColorViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new ColorGetAllRequest());
            return View(response);
        }
    }
}
