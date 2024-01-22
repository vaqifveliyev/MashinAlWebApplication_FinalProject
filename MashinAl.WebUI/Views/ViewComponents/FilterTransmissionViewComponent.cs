using MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Views.ViewComponents
{
    public class FilterTransmissionViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterTransmissionViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new TransmissionTypeGetAllRequest());
            return View(response);
        }
    }
}
