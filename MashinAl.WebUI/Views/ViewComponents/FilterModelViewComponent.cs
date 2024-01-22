using MashinAl.Business.Modules.ModelModule.Queries.ModelGetByMarkaIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterModelViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterModelViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new ModelGetByMarkaIdRequest());
            return View(response);
        }
    }
}
