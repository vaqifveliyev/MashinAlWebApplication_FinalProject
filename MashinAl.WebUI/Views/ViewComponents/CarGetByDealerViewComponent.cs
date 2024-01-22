using MashinAl.Business.Modules.CarModule.Queries.CarGetAllByDealerQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class CarGetByDealerViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public CarGetByDealerViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var data = await mediator.Send(new CarGetAllByDealerListRequest { Id = id});
            return View(data);
        }

    }
}
