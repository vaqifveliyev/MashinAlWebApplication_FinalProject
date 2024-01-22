using MashinAl.Business.Modules.AccountModule.Queries.DealerGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    [AllowAnonymous]
    public class DealershipController : Controller
    {
        private readonly IMediator mediator;
            
        public DealershipController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("avtosalonlar/{id}")]
        public async Task<IActionResult> Dealer([FromRoute] DealerGetByIdRequest request)
        {
           
            var data = await mediator.Send(request);
            return View(data);
        }
    }
}
