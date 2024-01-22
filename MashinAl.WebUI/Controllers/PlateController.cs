using MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    [AllowAnonymous]
    public class PlateController : Controller
    {
        
        private readonly IMediator mediator;

        public PlateController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("nomreler/elan/{id}")]
        public async Task<IActionResult> Details(PlateGetByIdRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }
    }
}
