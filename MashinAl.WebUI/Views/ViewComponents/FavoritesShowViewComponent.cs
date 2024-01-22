using MashinAl.Business.Modules.CarModule.Queries.FavoritesListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FavoritesShowViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FavoritesShowViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new FavoritesListRequest());
            return View(response);
        }
    }
}
