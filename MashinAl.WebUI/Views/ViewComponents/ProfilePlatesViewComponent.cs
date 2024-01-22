using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class ProfilePlatesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProfilePlatesViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new PlateGetAllByUserRequest());
            return View(response);
        }
    }
}
